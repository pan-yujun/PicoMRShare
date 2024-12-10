using UnityEngine;
using System.Collections;

//enum UpdateType {onStartOnly=0, editorIfSelected=1, editorAlways=2, editorAndPlaymode=3};
//@HideInInspector private var oldTileOffset : float = -1;
public enum SplineBendAxis
{
    x = 0,
    y = 1,
    z = 2
}

[System.Serializable]
[UnityEngine.ExecuteInEditMode]
public partial class SplineBend : MonoBehaviour
{
    public SplineBendMarker[] markers;
    [UnityEngine.HideInInspector]
    public bool showMeshes;
    [UnityEngine.HideInInspector]
    public bool showTiles;
    [UnityEngine.HideInInspector]
    public bool showTerrain;
    [UnityEngine.HideInInspector]
    public bool showUpdate;
    [UnityEngine.HideInInspector]
    public bool showExport;
    [UnityEngine.HideInInspector]
    public Mesh initialRenderMesh;
    [UnityEngine.HideInInspector]
    public Mesh renderMesh;
    [UnityEngine.HideInInspector]
    public Mesh initialCollisionMesh;
    [UnityEngine.HideInInspector]
    public Mesh collisionMesh;
    [UnityEngine.HideInInspector]
    public int tiles;
    [UnityEngine.HideInInspector]
    public float tileOffset;
    [UnityEngine.HideInInspector]
    private int oldTiles;
    [UnityEngine.HideInInspector]
    public bool dropToTerrain;
    [UnityEngine.HideInInspector]
    public float terrainSeekDist;
    [UnityEngine.HideInInspector]
    public int terrainLayer;
    [UnityEngine.HideInInspector]
    public float terrainOffset;
    [UnityEngine.HideInInspector]
    public bool equalize;
    [UnityEngine.HideInInspector]
    public bool closed;
    [UnityEngine.HideInInspector]
    private bool wasClosed;
    [UnityEngine.HideInInspector]
    public float markerSize;
    [UnityEngine.HideInInspector]
    public bool displayRolloutOpen;
    [UnityEngine.HideInInspector]
    public bool settingsRolloutOpen;
    [UnityEngine.HideInInspector]
    public bool terrainRolloutOpen;
    public SplineBendAxis axis;
    private Vector3 axisVector;
    //@HideInInspector var startCap : Transform;
    //@HideInInspector var endCap : Transform;
    //@HideInInspector var updateType : UpdateType = UpdateType.editorIfSelected;
    [UnityEngine.HideInInspector]
    public Transform objFile;
    public static Vector3 GetBeizerPoint(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float t)
    {
        float it = 1 - t;
        return (((((it * it) * it) * p0) + ((((3 * t) * it) * it) * p1)) + ((((3 * t) * t) * it) * p2)) + (((t * t) * t) * p3);
    }

    public static float GetBeizerLength(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3)//sqrt(1/5a + 1/4b + 1/2d + 1/3c + e)
    {
        Vector3 curPoint = default(Vector3);
        float length = 0;
        Vector3 oldPoint = p0;
        float i = 0;
        while (i < 1.01f)
        {
            curPoint = SplineBend.GetBeizerPoint(p0, p1, p2, p3, i);
            length = length + (oldPoint - curPoint).magnitude;
            oldPoint = curPoint;
            i = i + 0.1f;
        }
        return length;
    }

    public static float GetBeizerLength(SplineBendMarker marker1, SplineBendMarker marker2)
    {
        float dist = (marker2.position - marker1.position).magnitude * 0.5f;
        return SplineBend.GetBeizerLength(marker1.position, marker1.nextHandle + marker1.position, marker2.prewHandle + marker2.position, marker2.position);
    }

    public static Vector3 AlignPoint(SplineBendMarker marker1, SplineBendMarker marker2, float percent, Vector3 coords)
    {
         //var dist : float = marker1.dist + marker1.distAdjustRight*coords.z + marker1.distAdjustUp*coords.y;
        float dist = (marker2.position - marker1.position).magnitude * 0.5f;
        //picking two points on a beizer curve
        Vector3 pointBefore = SplineBend.GetBeizerPoint(marker1.position, marker1.nextHandle + marker1.position, marker2.prewHandle + marker2.position, marker2.position, Mathf.Max(0, percent - 0.01f));
        Vector3 pointAfter = SplineBend.GetBeizerPoint(marker1.position, marker1.nextHandle + marker1.position, marker2.prewHandle + marker2.position, marker2.position, Mathf.Min(1, percent + 0.01f));
        //getting main curve point and its tangent
        //var point : Vector3 = (pointAfter + pointBefore)*0.5; //inaccurate
        Vector3 point = SplineBend.GetBeizerPoint(marker1.position, marker1.nextHandle + marker1.position, marker2.prewHandle + marker2.position, marker2.position, percent);
        Vector3 tangent = pointBefore - pointAfter;
        //getting right and up vectors
        Vector3 orientation = Vector3.Slerp(marker1.up, marker2.up, percent);
        Vector3 perpRight = Vector3.Cross(tangent, orientation).normalized;
        Vector3 perpUp = Vector3.Cross(perpRight, tangent).normalized;
        //calculating marker-based scale
        Vector3 scale = new Vector3(1, 1, 1);
        if (marker1.expandWithScale || marker2.expandWithScale)
        {
            float sp1 = percent * percent;
            float sp2 = 1 - ((1 - percent) * (1 - percent));
            float sp = (sp2 * percent) + (sp1 * (1 - percent));
            scale.x = (marker1.transform.localScale.x * (1 - sp)) + (marker2.transform.localScale.x * sp);
            scale.y = (marker1.transform.localScale.y * (1 - sp)) + (marker2.transform.localScale.y * sp);
        }
        //returning result
        return (point + ((perpRight * coords.x) * scale.x)) + ((perpUp * coords.y) * scale.y);
    }

    public virtual void BuildMesh(Mesh mesh, Mesh initialMesh, int num, float offset)
    {
        int v = 0;
        //get initial arrays
        Vector3[] vertices = initialMesh.vertices;
        Vector2[] uvs = initialMesh.uv;
        Vector2[] uv2 = initialMesh.uv2;
        int[] tris = initialMesh.triangles;
        Vector4[] tangents = initialMesh.tangents;
        //changing axis
        //setting tiled arrays
        Vector3[] tiledVerts = new Vector3[vertices.Length * num];
        Vector2[] tiledUvs = new Vector2[vertices.Length * num];
        Vector2[] tiledUv2 = new Vector2[vertices.Length * num];
        Vector4[] tiledTangents = new Vector4[vertices.Length * num];
        bool hasSecondUv = uv2.Length > 0;
        int i = 0;
        while (i < num)
        {
            v = 0;
            while (v < vertices.Length)
            {
                tiledVerts[(i * vertices.Length) + v] = vertices[v];// + Vector3(0, 0, 1)*tileOffset*i; //we'll do it in Align
                tiledUvs[(i * vertices.Length) + v] = uvs[v];
                //if (hasSecondUv) tiledUv2[i*vertices.length + v] = uv2[v];
                tiledTangents[(i * vertices.Length) + v] = tangents[v];
                v++;
            }
            i++;
        }
        int[] tiledTris = new int[tris.Length * num];
        i = 0;
        while (i < num)
        {
            v = 0;
            while (v < tris.Length)
            {
                tiledTris[(i * tris.Length) + v] = tris[v] + (vertices.Length * i);
                v++;
            }
            i++;
        }
        //assigning arrays
        mesh.Clear();
        mesh.vertices = tiledVerts;
        mesh.uv = tiledUvs;
        mesh.uv2 = tiledUv2;
        mesh.triangles = tiledTris;
        mesh.tangents = tiledTangents;
        //	mesh.vertices = initialMesh.vertices;
        //	mesh.uv = initialMesh.uv;
        //	mesh.triangles = initialMesh.triangles;
        mesh.RecalculateNormals();
    }

    public virtual void RebuildMeshes() //on changing tile count, actually
    {
        if (!!this.renderMesh)
        {
            MeshFilter fil = (MeshFilter) this.GetComponent(typeof(MeshFilter));
            if (!fil) return;
            this.renderMesh.Clear();
            this.BuildMesh(this.renderMesh, this.initialRenderMesh, this.tiles, this.tileOffset);
            fil.sharedMesh = this.renderMesh;
            this.renderMesh.RecalculateBounds();
            this.renderMesh.RecalculateNormals();
        }
        if (!!this.collisionMesh)
        {
            MeshCollider col = (MeshCollider) this.GetComponent(typeof(MeshCollider));
            if (!col) return;
            this.collisionMesh.Clear();
            this.BuildMesh(this.collisionMesh, this.initialCollisionMesh, this.tiles, this.tileOffset);
            col.sharedMesh = null;
            col.sharedMesh = this.collisionMesh;
            this.collisionMesh.RecalculateBounds();
            this.collisionMesh.RecalculateNormals();
        }
    }

    public virtual void Align(Mesh mesh, Mesh initialMesh)
    {
        float boundsSize = 0.0f;
        int sp = 0;
        float distFromSubpoint = 0.0f;
         //generating 'straight' mesh array. Do not use sourceVerts anymore
        Vector3[] verts = new Vector3[mesh.vertexCount];
        Vector3[] sourceVerts = initialMesh.vertices;
        for (int i = 0; i < tiles; i++)
            for (int v = 0; v < sourceVerts.Length; v++)
            {
                int nv = i * sourceVerts.Length + v;
                verts[nv] = sourceVerts[v] + axisVector * tileOffset * i;
                if (axis == SplineBendAxis.x) verts[nv] = new Vector3(-verts[nv].z, verts[nv].y, verts[nv].x);
                else if (axis == SplineBendAxis.y) verts[nv] = new Vector3(-verts[nv].x, verts[nv].z, verts[nv].y);
            }

        //reseting bounds size
        float minPoint = Mathf.Infinity;
        float maxPoint = Mathf.NegativeInfinity;
        for (int v = 0; v < verts.Length; v++)
        {
            minPoint = Mathf.Min(minPoint, verts[v].z);
            maxPoint = Mathf.Max(maxPoint, verts[v].z);
        }
        boundsSize = maxPoint - minPoint;

        //placing verts

        for (int v = 0; v < verts.Length; v++)
        {
             //calculating percent of each mesh vert
            double percent = (verts[v].z - minPoint) / boundsSize;
            percent = Mathf.Clamp01((float) percent);
            if (Mathf.Approximately(boundsSize, 0))
            {
                percent = 0; //devision by zero
            }
            //calculating marker num
            int markerNum = 0;
            int m = 1;
            while (m < this.markers.Length)
            {
                if (this.markers[m].percent >= percent)
                {
                    markerNum = m - 1;
                    break;
                } //note that markerNum cannot be the last marker
                m++;
            }
            if (this.closed && (percent < this.markers[1].percent))
            {
                markerNum = 0;
            }
            //calculating relative percent
            float relativePercent = (float) ((percent - this.markers[markerNum].percent) / (this.markers[markerNum + 1].percent - this.markers[markerNum].percent));
            if (this.closed && (percent < this.markers[1].percent))
            {
                relativePercent = (float) (percent / this.markers[1].percent);
            }
            //equalizing
            if (this.equalize)
            {
                int s = 1;
                while (s < this.markers[markerNum].subPoints.Length)
                {
                    if (this.markers[markerNum].subPointPercents[s] >= relativePercent)
                    {
                        sp = s - 1;
                        break;
                    }
                    s++;
                }
                distFromSubpoint = (relativePercent - this.markers[markerNum].subPointPercents[sp]) * this.markers[markerNum].subPointFactors[sp];
                relativePercent = this.markers[markerNum].subPointMustPercents[sp] + distFromSubpoint;
            }

            //setting
            verts[v] = SplineBend.AlignPoint(this.markers[markerNum], this.markers[markerNum + 1], relativePercent, verts[v]);
        }
        mesh.vertices = verts;
    }

    public virtual void FallToTerrain(Mesh mesh, Mesh initialMesh, float seekDist, int layer, float offset)
    {
        RaycastHit hit = default(RaycastHit);
        Vector3[] verts = mesh.vertices;
        //generating array of original vert heights
        float[] heights = new float[mesh.vertexCount];
        Vector3[] sourceVerts = initialMesh.vertices; //Will not use sourceVerts anymore
        switch (this.axis)
        {
            case SplineBendAxis.z:
            case SplineBendAxis.x:
                for (int i = 0; i < tiles; i++)
                    for (int v = 0; v < sourceVerts.Length; v++)
                        heights[i * sourceVerts.Length + v] = sourceVerts[v].y;
                break;
            case SplineBendAxis.y:
                for (int i = 0; i < tiles; i++)
                    for (int v = 0; v < sourceVerts.Length; v++)
                        heights[i * sourceVerts.Length + v] = sourceVerts[v].z;
                break;
        }
        //flooring verts
        int oldLayer = this.gameObject.layer;
        this.gameObject.layer = 1 << 2;

        for (int v = 0; v < verts.Length; v++)
        {
            Vector3 globalVert = this.transform.TransformPoint(verts[v]);
            globalVert.y = this.transform.position.y;
            if (Physics.Raycast(globalVert + new Vector3(0, seekDist * 0.5f, 0), -Vector3.up, out hit, seekDist, 1 << layer))
            {
                verts[v].y = (heights[v] + this.transform.InverseTransformPoint(hit.point).y) + offset;
            }
        }
        this.gameObject.layer = oldLayer;
        mesh.vertices = verts;
    }

    public virtual void ResetMarkers()
    {
        this.ResetMarkers(this.markers.Length);
    }

    public virtual void ResetMarkers(int count)
    {
        Bounds bounds = default(Bounds);
        bool boundsFound = false;
        this.markers = new SplineBendMarker[count];
        //determining what mesh's bb shall be used
        Mesh initialMesh = null;
        if (!!this.initialRenderMesh)
        {
            initialMesh = this.initialRenderMesh;
        }
        else
        {
            if (!!this.initialCollisionMesh)
            {
                initialMesh = this.initialCollisionMesh;
            }
        }
        //getting mesh bounds
        if (!!this.initialRenderMesh)
        {
            bounds = this.initialRenderMesh.bounds;
            boundsFound = true;
        }
        else
        {
            if (!!this.initialCollisionMesh)
            {
                bounds = this.initialCollisionMesh.bounds;
                boundsFound = true;
            }
        }
        if (!boundsFound && !!((MeshFilter) this.GetComponent(typeof(MeshFilter))))
        {
            bounds = ((MeshFilter) this.GetComponent(typeof(MeshFilter))).sharedMesh.bounds;
            boundsFound = true;
        }
        if (!boundsFound && !!((MeshCollider) this.GetComponent(typeof(MeshCollider))))
        {
            bounds = ((MeshCollider) this.GetComponent(typeof(MeshCollider))).sharedMesh.bounds;
            boundsFound = true;
        }
        if (!boundsFound)
        {
            bounds = new Bounds(Vector3.zero, new Vector3(1, 1, 1));
        }
        float placementStart = bounds.min.z;
        float placementStep = bounds.size.z / (count - 1);
        int m = 0;
        while (m < count)
        {
            Transform markerTfm = new GameObject("Marker" + m).transform;
            markerTfm.parent = this.transform;
            markerTfm.localPosition = new Vector3(0, 0, placementStart + (placementStep * m));
            this.markers[m] = (SplineBendMarker) markerTfm.gameObject.AddComponent(typeof(SplineBendMarker));
            m++;
        }
    }

    public virtual void AddMarker(Vector3 coords)
    {
        int prewMarkerNum = 0;
        float curDistSq = 0.0f;
         //finding closest marker
        float distSq = Mathf.Infinity;
        int m = 0;
        while (m < this.markers.Length)
        {
            curDistSq = (this.markers[m].position - coords).sqrMagnitude;
            if (curDistSq < distSq)
            {
                prewMarkerNum = m;
                distSq = curDistSq;
            }
            m++;
        }
        this.AddMarker(prewMarkerNum, coords);
    }

    public virtual void AddMarker(Ray camRay) //adding marker closest to the given ray
    {
        int closestMarker = 0;
        int closestSubpoint = 0;
         //finding marker
        float closestDist = Mathf.Infinity;
        //var currentDist : float;
        int m = 0;
        while (m < this.markers.Length)
        {
            SplineBendMarker marker = this.markers[m];
            int s = 0;
            while (s < marker.subPoints.Length)
            {
                 //finding shortest distance between camRay and point
                Vector3 subPointPos = this.transform.TransformPoint(marker.subPoints[s]);
                float rayLength = Vector3.Dot(camRay.direction, (subPointPos - camRay.origin).normalized) * (camRay.origin - subPointPos).magnitude;
                float currentDist = ((camRay.origin + (camRay.direction * rayLength)) - subPointPos).magnitude;
                if (currentDist < closestDist)
                {
                    closestMarker = m;
                    closestSubpoint = s;
                    closestDist = currentDist;
                }
                s++;
            }
            m++;
        }
        //closestPointPos = transform.TransformPoint(marker.subPoints[s]);
        Vector3 pointPos = this.transform.TransformPoint(this.markers[closestMarker].subPoints[closestSubpoint]);
        float dist = (camRay.origin - pointPos).magnitude;
        this.AddMarker(closestMarker, camRay.origin + (camRay.direction * dist));
        this.UpdateNow();
        this.UpdateNow();
    }

    public virtual void AddMarker(int prewMarkerNum, Vector3 coords)
    {
         /*
	//re-assigning prewNum to previous in array if necessary
	if (prewMarkerNum>=1)
	{
		if ((coords - markers[prewMarkerNum-1].position).sqrMagnitude <
			(markers[prewMarkerNum-1].position - markers[prewMarkerNum].position).sqrMagnitude) 
				prewMarkerNum = prewMarkerNum-1;
	}
	else //if prewMarkerNum==0
	{
		if ((coords - markers[1].position).sqrMagnitude >
			(markers[0].position - markers[1].position).sqrMagnitude) 
				prewMarkerNum = -1;
	}
	*/
         //re-creating markers array
        SplineBendMarker[] newMarkers = new SplineBendMarker[this.markers.Length + 1];
        int m = 0;
        while (m < this.markers.Length)
        {
            if (m <= prewMarkerNum)
            {
                newMarkers[m] = this.markers[m];
            }
            else
            {
                newMarkers[m + 1] = this.markers[m];
            }
            m++;
        }
        //creating gameobject
        Transform markerTfm = new GameObject("Marker" + (prewMarkerNum + 1)).transform;
        markerTfm.parent = this.transform;
        markerTfm.position = coords;
        newMarkers[prewMarkerNum + 1] = (SplineBendMarker) markerTfm.gameObject.AddComponent(typeof(SplineBendMarker));
        this.markers = newMarkers;
    }

    public virtual void RefreshMarkers() //re-creates markers array ignoring non-existent ones
    {
        int newCount = 0;
        int m = 0;
        while (m < this.markers.Length)
        {
            if (!!this.markers[m])
            {
                newCount++;
            }
            m++;
        }
        SplineBendMarker[] newMarkers = new SplineBendMarker[newCount];
        int counter = 0;
        m = 0;
        while (m < this.markers.Length)
        {
            if (!this.markers[m])
            {
                goto Label_for_23;
            }
            newMarkers[counter] = this.markers[m];
            counter++;
            Label_for_23:
            m++;
        }
        this.markers = newMarkers;
    }

    public virtual void RemoveMarker(int num)
    {
         //destroing game object
        UnityEngine.Object.DestroyImmediate(this.markers[num].gameObject);
        //re-creating markers array
        SplineBendMarker[] newMarkers = new SplineBendMarker[this.markers.Length - 1];
        int m = 0;
        while (m < (this.markers.Length - 1))
        {
            if (m < num)
            {
                newMarkers[m] = this.markers[m];
            }
            else
            {
                newMarkers[m] = this.markers[m + 1];
            }
            m++;
        }
        this.markers = newMarkers;
    }

    public virtual void CloseMarkers()
    {
        if (this.closed || (this.markers[0] == this.markers[this.markers.Length - 1])) //already closed
        {
            return;
        }
        SplineBendMarker[] newMarkers = new SplineBendMarker[this.markers.Length + 1];
        int m = 0;
        while (m < this.markers.Length)
        {
            newMarkers[m] = this.markers[m];
            m++;
        }
        this.markers = newMarkers;
        this.markers[this.markers.Length - 1] = this.markers[0];
        this.UpdateNow();
        this.closed = true;
    }

    public virtual void UnCloseMarkers()
    {
        if (!this.closed || (this.markers[0] != this.markers[this.markers.Length - 1])) //already unclosed
        {
            return;
        }
        SplineBendMarker[] newMarkers = new SplineBendMarker[this.markers.Length - 1];
        int m = 0;
        while (m < (this.markers.Length - 1))
        {
            newMarkers[m] = this.markers[m];
            m++;
        }
        this.markers = newMarkers;
        this.UpdateNow();
        this.closed = false;
    }

    public virtual void OnEnable()
    {
         //removing render and collision mehses to prevent using same mesh by many SplineBends
        this.renderMesh = null;
        this.collisionMesh = null;
        this.ForceUpdate();
        MeshFilter f = (MeshFilter) this.GetComponent(typeof(MeshFilter));
        MeshCollider c = (MeshCollider) this.GetComponent(typeof(MeshCollider));
        if (!!this.renderMesh && !!f)
        {
            f.sharedMesh = this.renderMesh;
        }
        if (!!this.collisionMesh && !!c)
        {
            c.sharedMesh = null;
            c.sharedMesh = this.collisionMesh;
        }
    }

    public virtual void OnDisable()
    {
        MeshFilter f = (MeshFilter) this.GetComponent(typeof(MeshFilter));
        MeshCollider c = (MeshCollider) this.GetComponent(typeof(MeshCollider));
        if (!!this.initialRenderMesh && !!f)
        {
            f.sharedMesh = this.initialRenderMesh;
        }
        if (!!this.initialCollisionMesh && !!c)
        {
            c.sharedMesh = null;
            c.sharedMesh = this.initialCollisionMesh;
        }
    }

    public virtual void UpdateNow()
    {
        this.ForceUpdate(true);
    }

    public virtual void ForceUpdate()
    {
        this.ForceUpdate(true);
    }

    public virtual void ForceUpdate(bool refreshCollisionMesh)
    {
        MeshCollider collider = (MeshCollider) this.GetComponent(typeof(MeshCollider));
        MeshFilter filter = (MeshFilter) this.GetComponent(typeof(MeshFilter));
        switch (this.axis)
        {
            case SplineBendAxis.x: axisVector = new Vector3(1, 0, 0); break;
            case SplineBendAxis.y: axisVector = new Vector3(0, 1, 0); break;
            case SplineBendAxis.z: axisVector = new Vector3(0, 0, 1); break;
        }
        //limiting tiles numbers
        if (!!initialRenderMesh) tiles = Mathf.Min(tiles, Mathf.FloorToInt(65000f / initialRenderMesh.vertices.Length));
        else if (!!initialCollisionMesh) tiles = Mathf.Min(tiles, Mathf.FloorToInt(65000f / initialCollisionMesh.vertices.Length));
        tiles = Mathf.Max(tiles, 1);

        //refreshing or recreating markers
        if (markers == null) ResetMarkers(2);
        for (int m = 0; m < markers.Length; m++)
            if (!markers[m]) RefreshMarkers();
        if (markers.Length < 2) ResetMarkers(2);

        //initializing markers, setting position, handles and distance
        for (int m = 0; m < markers.Length; m++) markers[m].Init(this, m);
        if (closed) markers[0].dist = markers[markers.Length - 2].dist + GetBeizerLength(markers[markers.Length - 2], markers[0]);

        //setting marker percents
        float totalDist = markers[markers.Length - 1].dist;
        if (closed) totalDist = markers[0].dist;
        for (int m = 0; m < markers.Length; m++) markers[m].percent = markers[m].dist / totalDist;

        //closing - unclosing
        if (closed && !wasClosed) CloseMarkers();
        if (!closed && wasClosed) UnCloseMarkers();
        wasClosed = closed;

        //init meshes
        if (!!filter && !this.renderMesh) //if there is a filter but no render mesh
        {
            if (!this.initialRenderMesh)
            {
                this.initialRenderMesh = filter.sharedMesh; //if no mesh (object just loaded) then copy mesh to initial and assigning new one
            }
            if (!!this.initialRenderMesh)
            {
                 //reseting tile offset (if it is negative - upon first creation)
                if (this.tileOffset < 0)
                {
                    this.tileOffset = this.initialRenderMesh.bounds.size.z;
                }
                //creating working mesh
                this.renderMesh = UnityEngine.Object.Instantiate(this.initialRenderMesh);
                this.renderMesh.hideFlags = HideFlags.HideAndDontSave; //meshes must not save with a scene
                filter.sharedMesh = this.renderMesh;
            }
        }
        if (!!collider && !this.collisionMesh) //if there is collider but no collision mesh
        {
            if (!this.initialCollisionMesh)
            {
                this.initialCollisionMesh = collider.sharedMesh;
            }
            if (!!this.initialCollisionMesh)
            {
                 //reseting tile offset (if it is negative - upon first creation)
                if (this.tileOffset < 0)
                {
                    this.tileOffset = this.initialCollisionMesh.bounds.size.z;
                }
                //creating working mesh
                this.collisionMesh = UnityEngine.Object.Instantiate(this.initialCollisionMesh);
                this.collisionMesh.hideFlags = HideFlags.HideAndDontSave; //meshes must not save with a scene
                collider.sharedMesh = this.collisionMesh;
            }
        }
        //updating render mesh: rebuilding if needed, aligning, dropping
        if ((!!this.renderMesh && !!this.initialRenderMesh) && !!filter)
        {
            if (this.renderMesh.vertexCount != (this.initialRenderMesh.vertexCount * this.tiles))
            {
                this.BuildMesh(this.renderMesh, this.initialRenderMesh, this.tiles, 0);
            }
            this.Align(this.renderMesh, this.initialRenderMesh);
            if (this.dropToTerrain)
            {
                this.FallToTerrain(this.renderMesh, this.initialRenderMesh, this.terrainSeekDist, this.terrainLayer, this.terrainOffset);
            }
            //refreshing
            this.renderMesh.RecalculateBounds();
            this.renderMesh.RecalculateNormals();
        }
        //updating collision mesh. The same
        if ((!!this.collisionMesh && !!this.initialCollisionMesh) && !!collider)
        {
            if (this.collisionMesh.vertexCount != (this.initialCollisionMesh.vertexCount * this.tiles))
            {
                this.BuildMesh(this.collisionMesh, this.initialCollisionMesh, this.tiles, 0);
            }
            this.Align(this.collisionMesh, this.initialCollisionMesh);
            if (this.dropToTerrain)
            {
                this.FallToTerrain(this.collisionMesh, this.initialCollisionMesh, this.terrainSeekDist, this.terrainLayer, this.terrainOffset);
            }
            //refreshing
            if (refreshCollisionMesh && (collider.sharedMesh == this.collisionMesh)) //if refresh needed and collider mesh assigned to collider
            {
                this.collisionMesh.RecalculateBounds();
                this.collisionMesh.RecalculateNormals();
                collider.sharedMesh = null;
                collider.sharedMesh = this.collisionMesh;
            }
        }
    }

    public SplineBend()
    {
        this.tiles = 1;
        this.tileOffset = -1;
        this.oldTiles = 1;
        this.terrainSeekDist = 1000;
        this.equalize = true;
        this.markerSize = 1;
        this.axis = SplineBendAxis.z;
    }

}