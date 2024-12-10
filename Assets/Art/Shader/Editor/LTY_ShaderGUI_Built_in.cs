using System;
using UnityEngine;
using UnityEditor;


//����һ��GUI��
public class LTY_ShaderGUI_Built_in : ShaderGUI
{

    //�Զ���һ��С��ť
    public GUILayoutOption[] shortButtonStyle = new GUILayoutOption[] { GUILayout.Width(100) };

    //�Զ�������
    public GUIStyle style = new GUIStyle();

    //�Զ��������˵�����״����

    //�õ����Զ��������˵�
    static bool Foldout(bool display, string title)
    {
        var style = new GUIStyle("ShurikenModuleTitle");
        //����
        style.font = new GUIStyle(EditorStyles.boldLabel).font;
        //�߽�
        style.border = new RectOffset(15, 7, 4, 4);
        //����̶��߶�
        style.fixedHeight = 22;
        //����ƫ��  ��һ������Ϊ�����ұ���  �ڶ�������Ϊ������ƫ��
        style.contentOffset = new Vector2(20f, -3f);
        //�����С
        style.fontSize = 12;
        //������ɫ
        style.normal.textColor = new Color(0.75f, 0.85f, 0.95f);

        //���
        var rect = GUILayoutUtility.GetRect(16f, 25f, style);
        GUI.Box(rect, title, style);

        //��ǰ�¼�
        var e = Event.current;

        //��������  ���Ͻ�X���� ���Ͻ�X����  ���εĿ� ���εĸ�
        var toggleRect = new Rect(rect.x + 4f, rect.y + 2f, 13f, 13f);
        //����������
        if (e.type == EventType.Repaint)
        {
            EditorStyles.foldout.Draw(toggleRect, false, false, display, false);
        }

        //�������  ��������ھ��η�Χ��
        if (e.type == EventType.MouseDown && rect.Contains(e.mousePosition))
        {
            display = !display;
            e.Use();
        }

        return display;
    }



    //�Զ��������˵�2����״���� û�õ��Ĳ˵���ɫ
    static bool Foldout2(bool display, string title)
    {
        var style = new GUIStyle("ShurikenModuleTitle");
        //����
        style.font = new GUIStyle(EditorStyles.boldLabel).font;
        //�߽�
        style.border = new RectOffset(15, 7, 4, 4);
        //����̶��߶�
        style.fixedHeight = 22;
        //����ƫ��  ��һ������Ϊ�����ұ���  �ڶ�������Ϊ������ƫ��
        style.contentOffset = new Vector2(20f, -3f);
        //�����С
        style.fontSize = 12;
        //������ɫ
        style.normal.textColor = new Color(0.8f, 0.8f, 0.8f);

        //���
        var rect = GUILayoutUtility.GetRect(16f, 25f, style);
        GUI.Box(rect, title, style);

        //��ǰ�¼�
        var e = Event.current;

        //��������  ���Ͻ�X���� ���Ͻ�X����  ���εĿ� ���εĸ�
        var toggleRect = new Rect(rect.x + 4f, rect.y + 2f, 13f, 13f);
        //����������
        if (e.type == EventType.Repaint)
        {
            EditorStyles.foldout.Draw(toggleRect, false, false, display, false);
        }

        //�������  ��������ھ��η�Χ��
        if (e.type == EventType.MouseDown && rect.Contains(e.mousePosition))
        {
            display = !display;
            e.Use();
        }

        return display;
    }



    //�Զ������  ���漴�ٵĲ��� ���ʱ��������˵�  �ٵ�ʱ������������ Ĭ��Ϊ�棬�Ǽٵ�ʱ���л���foldout2
    static bool _Base_Foldout = true;
    static bool _Main_Foldout = true;
    static bool _Remap_Foldout = false;
    static bool _Mask_Foldout = false;
    static bool _Dissolve_Foldout = false;
    static bool _Distortion_Foldout = false;
    static bool _Fresnel_Foldout = false;
    static bool _WPO_Foldout = false;

    MaterialEditor m_MaterialEditor;


    //�Զ�����Ҫ��ͼ��Ҫ��ʾ������
    #region [��ͼ��ť����]

    #region [����ͼ��ť����]
    //����ͼ����
    MaterialProperty Main_Tex = null;

    MaterialProperty Main_Tex_Color = null;

    MaterialProperty Main_Tex_A_R = null;

    MaterialProperty Main_Tex_Custom_ZW = null;

    MaterialProperty Main_Tex_ClampSwitch = null;

    MaterialProperty Main_Tex_Rotator = null;

    MaterialProperty Main_Tex_U_speed = null;

    MaterialProperty Main_Tex_V_speed = null;

    MaterialProperty SoftParticle = null;

    #endregion

    #region [Remap��ͼ��ť����]
    //Remap����

    MaterialProperty Remap_Tex = null;

    MaterialProperty Remap_Tex_A_R = null;

    MaterialProperty Remap_Tex_Desaturate = null;

    MaterialProperty Remap_Tex_ClampSwitch = null;

    MaterialProperty Remap_Tex_Rotator = null;

    MaterialProperty Remap_Tex_Followl_Main_Tex = null;

    MaterialProperty Remap_Tex_U_speed = null;

    MaterialProperty Remap_Tex_V_speed = null;
    #endregion

    #region [������ͼ��ť����]
    //���ֲ���

    MaterialProperty Mask_Tex = null;

    MaterialProperty Mask_Tex_A_R = null;

    MaterialProperty Mask_Tex_ClampSwitch = null;

    MaterialProperty Mask_Tex_Rotator = null;

    MaterialProperty Mask_Tex_U_speed = null;

    MaterialProperty Mask_Tex_V_speed = null;
    #endregion

    #region [�ܽ���ͼ��ť����]
    //�ܽⲿ��

    MaterialProperty Dissolve_Tex = null;

    MaterialProperty Dissolve_Switch = null;

    MaterialProperty Dissolve_Tex_A_R = null;

    MaterialProperty Dissolve_Tex_Custom_X = null;

    MaterialProperty Dissolve_Tex_Rotator = null;

    MaterialProperty Dissolve_Tex_smooth = null;

    MaterialProperty Dissolve_Tex_power = null;

    MaterialProperty Dissolve_Tex_U_speed = null;

    MaterialProperty Dissolve_Tex_V_speed = null;
    #endregion

    #region [Ť����ͼ��ť����]
    //Ť������

    MaterialProperty Distortion_Tex = null;

    MaterialProperty Distortion_Switch = null;

    MaterialProperty Distortion_Tex_Power = null;

    MaterialProperty Distortion_Tex_U_speed = null;

    MaterialProperty Distortion_Tex_V_speed = null;
    #endregion

    #region [�������ť����]
    //���������

    MaterialProperty Fresnel_Color = null;

    MaterialProperty Fresnel_Switch = null;

    MaterialProperty Fresnel_Bokeh = null;

    MaterialProperty Fresnel_scale = null;

    MaterialProperty Fresnel_power = null;
    #endregion

    #region [����ƫ����ͼ��ť����]
    //����ƫ�Ʋ���

    MaterialProperty WPO_Tex = null;

    MaterialProperty WPO_Switch = null;

    MaterialProperty WPO_CustomSwitch_V = null;

    MaterialProperty WPO_tex_power = null;

    MaterialProperty WPO_Tex_Direction = null;

    MaterialProperty WPO_Tex_U_speed = null;

    MaterialProperty WPO_Tex_V_speed = null;
    #endregion

    #endregion

    //���ò�������(������İ�ť������ȡ��ֵ���Ա�������ʱȡ��)
    public void FindProperties(MaterialProperty[] props)
    {



        #region [����ͼ��ť��������]
        //����ͼ����ָ��

        Main_Tex = FindProperty("_Main_Tex", props);

        Main_Tex_Color = FindProperty("_Main_Tex_Color", props);

        Main_Tex_A_R = FindProperty("_Main_Tex_A_R", props);

        Main_Tex_Custom_ZW = FindProperty("_Main_Tex_Custom_ZW", props);

        Main_Tex_ClampSwitch = FindProperty("_Main_Tex_ClampSwitch", props);

        Main_Tex_Rotator = FindProperty("_Main_Tex_Rotator", props);

        Main_Tex_U_speed = FindProperty("_Main_Tex_U_speed", props);

        Main_Tex_V_speed = FindProperty("_Main_Tex_V_speed", props);

        SoftParticle = FindProperty("_SoftParticle", props);


        #endregion

        #region [Remap��ͼ��ť��������]
        //Remap����ָ��

        Remap_Tex = FindProperty("_Remap_Tex", props);

        Remap_Tex_A_R = FindProperty("_Remap_Tex_A_R", props);

        Remap_Tex_Desaturate = FindProperty("_Remap_Tex_Desaturate", props);

        Remap_Tex_ClampSwitch = FindProperty("_Remap_Tex_ClampSwitch", props);

        Remap_Tex_Rotator = FindProperty("_Remap_Tex_Rotator", props);

        Remap_Tex_Followl_Main_Tex = FindProperty("_Remap_Tex_Followl_Main_Tex", props);

        Remap_Tex_U_speed = FindProperty("_Remap_Tex_U_speed", props);

        Remap_Tex_V_speed = FindProperty("_Remap_Tex_V_speed", props);
        #endregion

        #region [������ͼ��ť��������]
        //���ֲ���

        Mask_Tex = FindProperty("_Mask_Tex", props);

        Mask_Tex_A_R = FindProperty("_Mask_Tex_A_R", props);

        Mask_Tex_ClampSwitch = FindProperty("_Mask_Tex_ClampSwitch", props);

        Mask_Tex_Rotator = FindProperty("_Mask_Tex_Rotator", props);

        Mask_Tex_U_speed = FindProperty("_Mask_Tex_U_speed", props);

        Mask_Tex_V_speed = FindProperty("_Mask_Tex_V_speed", props);
        #endregion 

        #region [�ܽ���ͼ��ť��������]
        //�ܽⲿ��

        Dissolve_Tex = FindProperty("_Dissolve_Tex", props);

        Dissolve_Switch = FindProperty("_Dissolve_Switch", props);

        Dissolve_Tex_A_R = FindProperty("_Dissolve_Tex_A_R", props);

        Dissolve_Tex_Custom_X = FindProperty("_Dissolve_Tex_Custom_X", props);

        Dissolve_Tex_Rotator = FindProperty("_Dissolve_Tex_Rotator", props);

        Dissolve_Tex_smooth = FindProperty("_Dissolve_Tex_smooth", props);

        Dissolve_Tex_power = FindProperty("_Dissolve_Tex_power", props);

        Dissolve_Tex_U_speed = FindProperty("_Dissolve_Tex_U_speed", props);

        Dissolve_Tex_V_speed = FindProperty("_Dissolve_Tex_V_speed", props);
        #endregion

        #region [Ť����ͼ��ť��������]
        //Ť������

        Distortion_Tex = FindProperty("_Distortion_Tex", props);

        Distortion_Switch = FindProperty("_Distortion_Switch", props);

        Distortion_Tex_Power = FindProperty("_Distortion_Tex_Power", props);

        Distortion_Tex_U_speed = FindProperty("_Distortion_Tex_U_speed", props);

        Distortion_Tex_V_speed = FindProperty("_Distortion_Tex_V_speed", props);
        #endregion

        #region [�������ť��������]
        //���������

        Fresnel_Color = FindProperty("_Fresnel_Color", props);

        Fresnel_Switch = FindProperty("_Fresnel_Switch", props);

        Fresnel_Bokeh = FindProperty("_Fresnel_Bokeh", props);

        Fresnel_scale = FindProperty("_Fresnel_scale", props);

        Fresnel_power = FindProperty("_Fresnel_power", props);
        #endregion

        #region [����ƫ����ͼ��ť��������]
        //����ƫ�Ʋ���

        WPO_Tex = FindProperty("_WPO_Tex", props);

        WPO_Switch = FindProperty("_WPO_Switch", props);

        WPO_CustomSwitch_V = FindProperty("_WPO_CustomSwitch_Y", props);

        WPO_tex_power = FindProperty("_WPO_tex_power", props);

        WPO_Tex_Direction = FindProperty("_WPO_Tex_Direction", props);

        WPO_Tex_U_speed = FindProperty("_WPO_Tex_U_speed", props);

        WPO_Tex_V_speed = FindProperty("_WPO_Tex_V_speed", props);
        #endregion 
    }


    //�����涨���������ʾ�������
    public override void OnGUI(MaterialEditor materialEditor, MaterialProperty[] props)
    {

        //��ȡ�������ϵĲ���
        FindProperties(props);
        m_MaterialEditor = materialEditor;
        //��ȡ�������ϵĲ���
        Material material = materialEditor.target as Material;


        //�������������˵�

        EditorGUILayout.BeginVertical(EditorStyles.helpBox);
        _Base_Foldout = Foldout(_Base_Foldout, "��������(BasicSettings)");

        if (_Base_Foldout)
        {
            EditorGUI.indentLevel++;




            //���ģʽ��ť��������
            {
                //���ƴ�ֱ�ķ���
                EditorGUILayout.BeginVertical(EditorStyles.helpBox);
                #region [���ģʽ]
                //���ƺ���ķ���
                EditorGUILayout.BeginHorizontal();

                EditorGUILayout.PrefixLabel("���ģʽ");

                if (material.GetFloat("_Dst") == 1)
                {
                    if (GUILayout.Button("Add", shortButtonStyle))
                    {
                        material.SetFloat("_Dst", 10);
                        material.EnableKeyword("_ISALPHA_ON");
                    }
                }
                else
                {
                    if (GUILayout.Button("Alpha", shortButtonStyle))
                    {
                        material.SetFloat("_Dst", 1);
                        material.DisableKeyword("_ISALPHA_ON");
                    }

                }
                EditorGUILayout.EndHorizontal();
                #endregion

                #region [�޳�ģʽ]

                EditorGUILayout.BeginHorizontal();
                {

                    EditorGUILayout.PrefixLabel("�޳�ģʽ");
                    if (material.GetFloat("_CullMode") == 0)
                    {
                        if (GUILayout.Button("˫����ʾ", shortButtonStyle))
                        {
                            material.SetFloat("_CullMode", 1);
                        }
                    }
                    else
                    {
                        if (material.GetFloat("_CullMode") == 1)
                        {
                            if (GUILayout.Button("��ʾ����", shortButtonStyle))
                            {
                                material.SetFloat("_CullMode", 2);
                            }
                        }

                        else
                        {
                            if (GUILayout.Button("��ʾ����", shortButtonStyle))
                            {
                                material.SetFloat("_CullMode", 0);
                            }
                        }

                    }

                }
                EditorGUILayout.EndHorizontal();

                #endregion

                #region ��ʾ����ǰ��
                EditorGUILayout.BeginHorizontal();

                EditorGUILayout.PrefixLabel("��ʾ����ǰ��");


                if (material.GetFloat("_ZTestMode") == 4)
                {
                    if (GUILayout.Button("��", shortButtonStyle))
                    {
                        material.SetFloat("_ZTestMode", 8);

                    }
                }
                else
                {
                    if (GUILayout.Button("��", shortButtonStyle))
                    {
                        material.SetFloat("_ZTestMode", 4);
                    }
                }

                EditorGUILayout.EndHorizontal();
                #endregion

                #region[д�����] 
                EditorGUILayout.BeginHorizontal();

                EditorGUILayout.PrefixLabel("д�����");


                if (material.GetFloat("_Zwrite") == 0)
                {
                    if (GUILayout.Button("��", shortButtonStyle))
                    {
                        material.SetFloat("_Zwrite", 1);

                    }
                }
                else
                {
                    if (GUILayout.Button("��", shortButtonStyle))
                    {
                        material.SetFloat("_Zwrite", 0);
                    }
                }

                EditorGUILayout.EndHorizontal();
                #endregion

                #region[������] 
                EditorGUILayout.BeginHorizontal();

                m_MaterialEditor.ShaderProperty(SoftParticle, "������");

                EditorGUILayout.EndHorizontal();
                #endregion

                EditorGUILayout.EndHorizontal();
                //������صĸ߶�
                GUILayout.Space(5);
            }



            EditorGUI.indentLevel--;
        }

        EditorGUILayout.EndVertical();

        //����ͼ�����˵�

        #region [����ͼ����]
        if (Main_Tex.textureValue != null)
        {
            EditorGUILayout.BeginVertical(EditorStyles.helpBox);

            _Main_Foldout = Foldout(_Main_Foldout, "����ͼ(MainTexture)");

            if (_Main_Foldout)
            {
                EditorGUI.indentLevel++;


                {

                    m_MaterialEditor.TexturePropertySingleLine(new GUIContent("����ͼ"), Main_Tex, Main_Tex_Color);



                    if (Main_Tex.textureValue != null)
                    {

                        m_MaterialEditor.TextureScaleOffsetProperty(Main_Tex);


                        EditorGUILayout.BeginVertical(EditorStyles.helpBox);
                        m_MaterialEditor.ShaderProperty(Main_Tex_A_R, "�л�ͨ��");

                        //���ʣ�����Ŀ���ô�ĳ���
                        m_MaterialEditor.ShaderProperty(Main_Tex_Rotator, "��ͼ��ת");

                        EditorGUILayout.BeginHorizontal();
                        EditorGUILayout.PrefixLabel("�л���ͼ����ģʽ");
                        #region [����ͼ����]
                        if (material.GetFloat("_Main_Tex_ClampSwitch") == 0)
                        {
                            if (GUILayout.Button("����", shortButtonStyle))
                            {
                                material.SetFloat("_Main_Tex_ClampSwitch", 1);
                            }

                        }
                        else
                        {
                            if (GUILayout.Button("������", shortButtonStyle))
                            {
                                material.SetFloat("_Main_Tex_ClampSwitch", 0);
                            }
                        }
                        EditorGUILayout.EndVertical();
                        #endregion


                        EditorGUILayout.BeginHorizontal();
                        EditorGUILayout.PrefixLabel("�Ƿ����Զ���UV������ZW��");

                        if (material.GetFloat("_Main_Tex_Custom_ZW") == 0)
                        {
                            if (GUILayout.Button("�ѹر�", shortButtonStyle))
                            {
                                material.SetFloat("_Main_Tex_Custom_ZW", 1);
                            }

                        }
                        else
                        {
                            if (GUILayout.Button("�ѿ���", shortButtonStyle))
                            {
                                material.SetFloat("_Main_Tex_Custom_ZW", 0);
                            }
                        }
                        EditorGUILayout.EndVertical();
                        EditorGUILayout.EndVertical();

                        if (material.GetFloat("_Main_Tex_Custom_ZW") == 0)

                        {
                            EditorGUILayout.BeginVertical(EditorStyles.helpBox);
                            m_MaterialEditor.ShaderProperty(Main_Tex_U_speed, "���������ٶ�");
                            m_MaterialEditor.ShaderProperty(Main_Tex_V_speed, "���������ٶ�");
                            EditorGUILayout.EndVertical();
                        }




                    }
                }

                EditorGUI.indentLevel--;
            }
            EditorGUILayout.EndVertical();
        }
        else
        {
            EditorGUILayout.BeginVertical(EditorStyles.helpBox);
            _Main_Foldout = Foldout2(_Main_Foldout, "����ͼ(MainTexture)");

            if (_Main_Foldout)
            {
                EditorGUI.indentLevel++;


                {

                    m_MaterialEditor.TexturePropertySingleLine(new GUIContent("����ͼ"), Main_Tex, Main_Tex_Color);



                    if (Main_Tex.textureValue != null)
                    {

                        m_MaterialEditor.TextureScaleOffsetProperty(Main_Tex);


                        EditorGUILayout.BeginVertical(EditorStyles.helpBox);
                        m_MaterialEditor.ShaderProperty(Main_Tex_A_R, "�л�ͨ��");

                        //���ʣ�����Ŀ���ô�ĳ���
                        m_MaterialEditor.ShaderProperty(Main_Tex_Rotator, "��ͼ��ת");

                        EditorGUILayout.BeginHorizontal();
                        EditorGUILayout.PrefixLabel("�л���ͼ����ģʽ");
                        #region [����ͼ����]
                        if (material.GetFloat("_Main_Tex_ClampSwitch") == 0)
                        {
                            if (GUILayout.Button("����", shortButtonStyle))
                            {
                                material.SetFloat("_Main_Tex_ClampSwitch", 1);
                            }

                        }
                        else
                        {
                            if (GUILayout.Button("������", shortButtonStyle))
                            {
                                material.SetFloat("_Main_Tex_ClampSwitch", 0);
                            }
                        }
                        EditorGUILayout.EndVertical();
                        #endregion


                        EditorGUILayout.BeginHorizontal();
                        EditorGUILayout.PrefixLabel("�Ƿ����Զ���UV������ZW��");

                        if (material.GetFloat("_Main_Tex_Custom_ZW") == 0)
                        {
                            if (GUILayout.Button("�ѹر�", shortButtonStyle))
                            {
                                material.SetFloat("_Main_Tex_Custom_ZW", 1);
                            }

                        }
                        else
                        {
                            if (GUILayout.Button("�ѿ���", shortButtonStyle))
                            {
                                material.SetFloat("_Main_Tex_Custom_ZW", 0);
                            }
                        }
                        EditorGUILayout.EndVertical();
                        EditorGUILayout.EndVertical();

                        if (material.GetFloat("_Main_Tex_Custom_ZW") == 0)

                        {
                            EditorGUILayout.BeginVertical(EditorStyles.helpBox);
                            m_MaterialEditor.ShaderProperty(Main_Tex_U_speed, "���������ٶ�");
                            m_MaterialEditor.ShaderProperty(Main_Tex_V_speed, "���������ٶ�");
                            EditorGUILayout.EndVertical();
                        }




                    }
                }

                EditorGUI.indentLevel--;
            }
            EditorGUILayout.EndVertical();
        }
        #endregion

        //��ɫ���������˵�

        #region [Remap����]
        if (Remap_Tex.textureValue != null)
        {
            EditorGUILayout.BeginVertical(EditorStyles.helpBox);

            _Remap_Foldout = Foldout(_Remap_Foldout, "��ɫ������ͼ(RemapTexture)");

            if (_Remap_Foldout)
            {
                EditorGUI.indentLevel++;

                {

                    m_MaterialEditor.TexturePropertySingleLine(new GUIContent("��ɫ������ͼ"), Remap_Tex);



                    if (Remap_Tex.textureValue != null)
                    {

                        m_MaterialEditor.TextureScaleOffsetProperty(Remap_Tex);


                        EditorGUILayout.BeginVertical(EditorStyles.helpBox);
                        m_MaterialEditor.ShaderProperty(Remap_Tex_A_R, "�л�ͨ��");

                        //���ʣ�����Ŀ���ô�ĳ���
                        m_MaterialEditor.ShaderProperty(Remap_Tex_Desaturate, "��ͼȥɫ");
                        m_MaterialEditor.ShaderProperty(Remap_Tex_Rotator, "��ͼ��ת");

                        EditorGUILayout.BeginHorizontal();
                        EditorGUILayout.PrefixLabel("�л���ͼ����");
                        #region [Remap��ͼ����]
                        if (material.GetFloat("_Remap_Tex_ClampSwitch") == 0)
                        {
                            if (GUILayout.Button("����", shortButtonStyle))
                            {
                                material.SetFloat("_Remap_Tex_ClampSwitch", 1);
                            }

                        }
                        else
                        {
                            if (GUILayout.Button("������", shortButtonStyle))
                            {
                                material.SetFloat("_Remap_Tex_ClampSwitch", 0);
                            }
                        }
                        EditorGUILayout.EndVertical();
                        #endregion

                        EditorGUILayout.BeginHorizontal();
                        EditorGUILayout.PrefixLabel("��������ͼһ����UV�ƶ�");

                        if (material.GetFloat("_Remap_Tex_Followl_Main_Tex") == 0)
                        {
                            if (GUILayout.Button("�ѹر�", shortButtonStyle))
                            {
                                material.SetFloat("_Remap_Tex_Followl_Main_Tex", 1);
                            }

                        }
                        else
                        {
                            if (GUILayout.Button("�ѿ���", shortButtonStyle))
                            {
                                material.SetFloat("_Remap_Tex_Followl_Main_Tex", 0);
                            }
                        }
                        EditorGUILayout.EndVertical();
                        EditorGUILayout.EndVertical();

                        if (material.GetFloat("_Remap_Tex_Followl_Main_Tex") == 0)

                        {
                            EditorGUILayout.BeginVertical(EditorStyles.helpBox);
                            m_MaterialEditor.ShaderProperty(Remap_Tex_U_speed, "���������ٶ�");
                            m_MaterialEditor.ShaderProperty(Remap_Tex_V_speed, "���������ٶ�");
                            EditorGUILayout.EndVertical();
                        }

                    }
                }

                EditorGUI.indentLevel--;
            }
            EditorGUILayout.EndVertical();
        }
        else
        {
            EditorGUILayout.BeginVertical(EditorStyles.helpBox);
            _Remap_Foldout = Foldout2(_Remap_Foldout, "��ɫ������ͼ(RemapTexture)");

            if (_Remap_Foldout)
            {
                EditorGUI.indentLevel++;

                {

                    m_MaterialEditor.TexturePropertySingleLine(new GUIContent("��ɫ������ͼ"), Remap_Tex);



                    if (Remap_Tex.textureValue != null)
                    {

                        m_MaterialEditor.TextureScaleOffsetProperty(Remap_Tex);


                        EditorGUILayout.BeginVertical(EditorStyles.helpBox);
                        m_MaterialEditor.ShaderProperty(Remap_Tex_A_R, "�л�ͨ��");

                        //���ʣ�����Ŀ���ô�ĳ���
                        m_MaterialEditor.ShaderProperty(Remap_Tex_Desaturate, "��ͼȥɫ");
                        m_MaterialEditor.ShaderProperty(Remap_Tex_Rotator, "��ͼ��ת");

                        EditorGUILayout.BeginHorizontal();
                        EditorGUILayout.PrefixLabel("�л���ͼ����");
                        #region [Remap��ͼ����]
                        if (material.GetFloat("_Remap_Tex_ClampSwitch") == 0)
                        {
                            if (GUILayout.Button("����", shortButtonStyle))
                            {
                                material.SetFloat("_Remap_Tex_ClampSwitch", 1);
                            }

                        }
                        else
                        {
                            if (GUILayout.Button("������", shortButtonStyle))
                            {
                                material.SetFloat("_Remap_Tex_ClampSwitch", 0);
                            }
                        }
                        EditorGUILayout.EndVertical();
                        #endregion

                        EditorGUILayout.BeginHorizontal();
                        EditorGUILayout.PrefixLabel("��������ͼһ����UV�ƶ�");

                        if (material.GetFloat("_Remap_Tex_Followl_Main_Tex") == 0)
                        {
                            if (GUILayout.Button("�ѹر�", shortButtonStyle))
                            {
                                material.SetFloat("_Remap_Tex_Followl_Main_Tex", 1);
                            }

                        }
                        else
                        {
                            if (GUILayout.Button("�ѿ���", shortButtonStyle))
                            {
                                material.SetFloat("_Remap_Tex_Followl_Main_Tex", 0);
                            }
                        }
                        EditorGUILayout.EndVertical();
                        EditorGUILayout.EndVertical();

                        if (material.GetFloat("_Remap_Tex_Followl_Main_Tex") == 0)

                        {
                            EditorGUILayout.BeginVertical(EditorStyles.helpBox);
                            m_MaterialEditor.ShaderProperty(Remap_Tex_U_speed, "���������ٶ�");
                            m_MaterialEditor.ShaderProperty(Remap_Tex_V_speed, "���������ٶ�");
                            EditorGUILayout.EndVertical();
                        }

                    }
                }

                EditorGUI.indentLevel--;
            }
            EditorGUILayout.EndVertical();
        }
        #endregion

        //���������˵�

        #region [���ֲ���]
        if (Mask_Tex.textureValue != null)
        {
            EditorGUILayout.BeginVertical(EditorStyles.helpBox);

            _Mask_Foldout = Foldout(_Mask_Foldout, "������ͼ(MaskTexture)");

            if (_Mask_Foldout)
            {
                EditorGUI.indentLevel++;



                {


                    m_MaterialEditor.TexturePropertySingleLine(new GUIContent("������ͼ"), Mask_Tex);



                    if (Mask_Tex.textureValue != null)
                    {

                        m_MaterialEditor.TextureScaleOffsetProperty(Mask_Tex);


                        EditorGUILayout.BeginVertical(EditorStyles.helpBox);
                        m_MaterialEditor.ShaderProperty(Mask_Tex_A_R, "�л�ͨ��");

                        //���ʣ�����Ŀ���ô�ĳ���
                        m_MaterialEditor.ShaderProperty(Mask_Tex_Rotator, "��ͼ��ת");

                        EditorGUILayout.BeginHorizontal();
                        EditorGUILayout.PrefixLabel("�л���ͼ����");
                        #region [������ͼ����]
                        if (material.GetFloat("_Mask_Tex_ClampSwitch") == 0)
                        {
                            if (GUILayout.Button("����", shortButtonStyle))
                            {
                                material.SetFloat("_Mask_Tex_ClampSwitch", 1);
                            }

                        }
                        else
                        {
                            if (GUILayout.Button("������", shortButtonStyle))
                            {
                                material.SetFloat("_Mask_Tex_ClampSwitch", 0);
                            }
                        }
                        EditorGUILayout.EndVertical();
                        #endregion


                        EditorGUILayout.EndVertical();

                        EditorGUILayout.BeginVertical(EditorStyles.helpBox);
                        m_MaterialEditor.ShaderProperty(Mask_Tex_U_speed, "���������ٶ�");
                        m_MaterialEditor.ShaderProperty(Mask_Tex_V_speed, "���������ٶ�");
                        EditorGUILayout.EndVertical();

                    }
                }

                EditorGUI.indentLevel--;
            }
            EditorGUILayout.EndVertical();
        }
        else
        {
            EditorGUILayout.BeginVertical(EditorStyles.helpBox);
            _Mask_Foldout = Foldout2(_Mask_Foldout, "������ͼ(MaskTexture)");

            if (_Mask_Foldout)
            {
                EditorGUI.indentLevel++;


                {


                    m_MaterialEditor.TexturePropertySingleLine(new GUIContent("������ͼ"), Mask_Tex);



                    if (Mask_Tex.textureValue != null)
                    {

                        m_MaterialEditor.TextureScaleOffsetProperty(Mask_Tex);


                        EditorGUILayout.BeginVertical(EditorStyles.helpBox);
                        m_MaterialEditor.ShaderProperty(Mask_Tex_A_R, "�л�ͨ��");

                        //���ʣ�����Ŀ���ô�ĳ���
                        m_MaterialEditor.ShaderProperty(Mask_Tex_Rotator, "��ͼ��ת");

                        EditorGUILayout.BeginHorizontal();
                        EditorGUILayout.PrefixLabel("�л���ͼ����");
                        #region [������ͼ����]
                        if (material.GetFloat("_Mask_Tex_ClampSwitch") == 0)
                        {
                            if (GUILayout.Button("����", shortButtonStyle))
                            {
                                material.SetFloat("_Mask_Tex_ClampSwitch", 1);
                            }

                        }
                        else
                        {
                            if (GUILayout.Button("������", shortButtonStyle))
                            {
                                material.SetFloat("_Mask_Tex_ClampSwitch", 0);
                            }
                        }
                        EditorGUILayout.EndVertical();
                        #endregion


                        EditorGUILayout.EndVertical();

                        EditorGUILayout.BeginVertical(EditorStyles.helpBox);
                        m_MaterialEditor.ShaderProperty(Mask_Tex_U_speed, "���������ٶ�");
                        m_MaterialEditor.ShaderProperty(Mask_Tex_V_speed, "���������ٶ�");
                        EditorGUILayout.EndVertical();

                    }
                }

                EditorGUI.indentLevel--;
            }
            EditorGUILayout.EndVertical();
        }
        #endregion

        //�ܽ������˵�

        #region [�ܽⲿ��]
        if (Dissolve_Tex.textureValue != null)
        {
            EditorGUILayout.BeginVertical(EditorStyles.helpBox);

            _Dissolve_Foldout = Foldout(_Dissolve_Foldout, "�ܽ���ͼ(DissolveTexture)");

            if (_Dissolve_Foldout)
            {
                EditorGUI.indentLevel++;

                {


                    m_MaterialEditor.TexturePropertySingleLine(new GUIContent("�ܽ���ͼ"), Dissolve_Tex);



                    if (Dissolve_Tex.textureValue != null)
                    {

                        m_MaterialEditor.TextureScaleOffsetProperty(Dissolve_Tex);


                        EditorGUILayout.BeginVertical(EditorStyles.helpBox);
                        m_MaterialEditor.ShaderProperty(Dissolve_Switch, "�ܽ⿪��");
                        m_MaterialEditor.ShaderProperty(Dissolve_Tex_A_R, "�л�ͨ��");


                        //���ʣ�����Ŀ���ô�ĳ���
                        m_MaterialEditor.ShaderProperty(Dissolve_Tex_Rotator, "��ͼ��ת");
                        m_MaterialEditor.ShaderProperty(Dissolve_Tex_smooth, "��Ӳ�ܽ����");
                        m_MaterialEditor.ShaderProperty(Dissolve_Tex_power, "�ܽ����");

                        EditorGUILayout.BeginHorizontal();
                        EditorGUILayout.PrefixLabel("�Ƿ������Զ�������ܽ⣨X��");

                        if (material.GetFloat("_Dissolve_Tex_Custom_X") == 0)
                        {
                            if (GUILayout.Button("�ѹر�", shortButtonStyle))
                            {
                                material.SetFloat("_Dissolve_Tex_Custom_X", 1);
                            }

                        }
                        else
                        {
                            if (GUILayout.Button("�ѿ���", shortButtonStyle))
                            {
                                material.SetFloat("_Dissolve_Tex_Custom_X", 0);
                            }
                        }
                        EditorGUILayout.EndVertical();

                        EditorGUILayout.EndVertical();

                        if (material.GetFloat("_Dissolve_Tex_Custom_X") == 0)

                        {
                            EditorGUILayout.BeginVertical(EditorStyles.helpBox);
                            m_MaterialEditor.ShaderProperty(Dissolve_Tex_U_speed, "���������ٶ�");
                            m_MaterialEditor.ShaderProperty(Dissolve_Tex_V_speed, "���������ٶ�");
                            EditorGUILayout.EndVertical();
                        }
                    }
                }

                EditorGUI.indentLevel--;
            }
            EditorGUILayout.EndVertical();
        }
        else
        {
            EditorGUILayout.BeginVertical(EditorStyles.helpBox);
            _Dissolve_Foldout = Foldout2(_Dissolve_Foldout, "�ܽ���ͼ(DissolveTexture)");

            if (_Dissolve_Foldout)
            {
                EditorGUI.indentLevel++;

                {


                    m_MaterialEditor.TexturePropertySingleLine(new GUIContent("�ܽ���ͼ"), Dissolve_Tex);



                    if (Dissolve_Tex.textureValue != null)
                    {

                        m_MaterialEditor.TextureScaleOffsetProperty(Dissolve_Tex);


                        EditorGUILayout.BeginVertical(EditorStyles.helpBox);
                        m_MaterialEditor.ShaderProperty(Dissolve_Switch, "�ܽ⿪��");
                        m_MaterialEditor.ShaderProperty(Dissolve_Tex_A_R, "�л�ͨ��");


                        //���ʣ�����Ŀ���ô�ĳ���
                        m_MaterialEditor.ShaderProperty(Dissolve_Tex_Rotator, "��ͼ��ת");
                        m_MaterialEditor.ShaderProperty(Dissolve_Tex_smooth, "��Ӳ�ܽ����");
                        m_MaterialEditor.ShaderProperty(Dissolve_Tex_power, "�ܽ����");

                        EditorGUILayout.BeginHorizontal();
                        EditorGUILayout.PrefixLabel("�Ƿ������Զ�������ܽ⣨X��");

                        if (material.GetFloat("_Dissolve_Tex_Custom_X") == 0)
                        {
                            if (GUILayout.Button("�ѹر�", shortButtonStyle))
                            {
                                material.SetFloat("_Dissolve_Tex_Custom_X", 1);
                            }

                        }
                        else
                        {
                            if (GUILayout.Button("�ѿ���", shortButtonStyle))
                            {
                                material.SetFloat("_Dissolve_Tex_Custom_X", 0);
                            }
                        }
                        EditorGUILayout.EndVertical();

                        EditorGUILayout.EndVertical();

                        if (material.GetFloat("_Dissolve_Tex_Custom_X") == 0)

                        {
                            EditorGUILayout.BeginVertical(EditorStyles.helpBox);
                            m_MaterialEditor.ShaderProperty(Dissolve_Tex_U_speed, "���������ٶ�");
                            m_MaterialEditor.ShaderProperty(Dissolve_Tex_V_speed, "���������ٶ�");
                            EditorGUILayout.EndVertical();
                        }
                    }
                }

                EditorGUI.indentLevel--;
            }
            EditorGUILayout.EndVertical();
        }
        #endregion

        //Ť�������˵�

        #region [Ť������]
        if (Distortion_Tex.textureValue != null)
        {
            EditorGUILayout.BeginVertical(EditorStyles.helpBox);

            _Distortion_Foldout = Foldout(_Distortion_Foldout, "Ť����ͼ(DistortionTexture)");

            if (_Distortion_Foldout)
            {
                EditorGUI.indentLevel++;

                {


                    m_MaterialEditor.TexturePropertySingleLine(new GUIContent("Ť����ͼ"), Distortion_Tex);



                    if (Distortion_Tex.textureValue != null)
                    {

                        m_MaterialEditor.TextureScaleOffsetProperty(Distortion_Tex);


                        EditorGUILayout.BeginVertical(EditorStyles.helpBox);
                        EditorGUILayout.BeginHorizontal();
                        EditorGUILayout.PrefixLabel("Ť������");

                        if (material.GetFloat("_Distortion_Switch") == 0)
                        {
                            if (GUILayout.Button("�ѹر�", shortButtonStyle))
                            {
                                material.SetFloat("_Distortion_Switch", 1);
                            }

                        }
                        else
                        {
                            if (GUILayout.Button("�ѿ���", shortButtonStyle))
                            {
                                material.SetFloat("_Distortion_Switch", 0);
                            }
                        }
                        EditorGUILayout.EndVertical();


                        m_MaterialEditor.ShaderProperty(Distortion_Tex_Power, "Ť��ǿ��");
                        EditorGUILayout.EndVertical();

                        EditorGUILayout.BeginVertical(EditorStyles.helpBox);
                        m_MaterialEditor.ShaderProperty(Distortion_Tex_U_speed, "���������ٶ�");
                        m_MaterialEditor.ShaderProperty(Distortion_Tex_V_speed, "���������ٶ�");
                        EditorGUILayout.EndVertical();

                    }
                }

                EditorGUI.indentLevel--;
            }
            EditorGUILayout.EndVertical();
        }
        else
        {
            EditorGUILayout.BeginVertical(EditorStyles.helpBox);
            _Distortion_Foldout = Foldout2(_Distortion_Foldout, "Ť����ͼ(DistortionTexture)");

            if (_Distortion_Foldout)
            {
                EditorGUI.indentLevel++;

                {


                    m_MaterialEditor.TexturePropertySingleLine(new GUIContent("Ť����ͼ"), Distortion_Tex);



                    if (Distortion_Tex.textureValue != null)
                    {

                        m_MaterialEditor.TextureScaleOffsetProperty(Distortion_Tex);


                        EditorGUILayout.BeginVertical(EditorStyles.helpBox);
                        EditorGUILayout.BeginHorizontal();
                        EditorGUILayout.PrefixLabel("Ť������");

                        if (material.GetFloat("_Distortion_Switch") == 0)
                        {
                            if (GUILayout.Button("�ѹر�", shortButtonStyle))
                            {
                                material.SetFloat("_Distortion_Switch", 1);
                            }

                        }
                        else
                        {
                            if (GUILayout.Button("�ѿ���", shortButtonStyle))
                            {
                                material.SetFloat("_Distortion_Switch", 0);
                            }
                        }
                        EditorGUILayout.EndVertical();


                        m_MaterialEditor.ShaderProperty(Distortion_Tex_Power, "Ť��ǿ��");
                        EditorGUILayout.EndVertical();

                        EditorGUILayout.BeginVertical(EditorStyles.helpBox);
                        m_MaterialEditor.ShaderProperty(Distortion_Tex_U_speed, "���������ٶ�");
                        m_MaterialEditor.ShaderProperty(Distortion_Tex_V_speed, "���������ٶ�");
                        EditorGUILayout.EndVertical();

                    }
                }

                EditorGUI.indentLevel--;
            }
            EditorGUILayout.EndVertical();
        }
        #endregion

        //����������˵�

        #region [���������]

        EditorGUILayout.BeginVertical(EditorStyles.helpBox);

        _Fresnel_Foldout = Foldout2(_Fresnel_Foldout, "�����������Ե���⣩");

        if (_Fresnel_Foldout)
        {
            EditorGUI.indentLevel++;

            {

                EditorGUILayout.BeginVertical(EditorStyles.helpBox);
                m_MaterialEditor.ShaderProperty(Fresnel_Color, "��������ɫ");
                m_MaterialEditor.ShaderProperty(Fresnel_Switch, "����������");
                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.PrefixLabel("������ģʽ");

                if (material.GetFloat("_Fresnel_Bokeh") == 0)
                {
                    if (GUILayout.Button("������", shortButtonStyle))
                    {
                        material.SetFloat("_Fresnel_Bokeh", 1);
                    }

                }
                else
                {
                    if (GUILayout.Button("��Ե�黯", shortButtonStyle))
                    {
                        material.SetFloat("_Fresnel_Bokeh", 0);
                    }
                }
                EditorGUILayout.EndVertical();

                m_MaterialEditor.ShaderProperty(Fresnel_scale, "����������");
                m_MaterialEditor.ShaderProperty(Fresnel_power, "������ǿ��");


                EditorGUILayout.EndVertical();
            }

            EditorGUI.indentLevel--;
        }
        EditorGUILayout.EndVertical();
        #endregion

        //����ƫ�������˵�

        #region [����ƫ�Ʋ���]
        if (WPO_Tex.textureValue != null)
        {
            EditorGUILayout.BeginVertical(EditorStyles.helpBox);

            _WPO_Foldout = Foldout(_WPO_Foldout, "����ƫ����ͼ(WPOTexture)");

            if (_WPO_Foldout)
            {
                EditorGUI.indentLevel++;

                {


                    m_MaterialEditor.TexturePropertySingleLine(new GUIContent("����ƫ����ͼ"), WPO_Tex);



                    if (WPO_Tex.textureValue != null)
                    {

                        m_MaterialEditor.TextureScaleOffsetProperty(WPO_Tex);


                        EditorGUILayout.BeginVertical(EditorStyles.helpBox);
                        m_MaterialEditor.ShaderProperty(WPO_Switch, "����ƫ�ƿ���");

                        EditorGUILayout.BeginHorizontal();
                        EditorGUILayout.PrefixLabel("�Զ��嶥��ƫ�ƿ��أ�Y��");

                        if (material.GetFloat("_WPO_CustomSwitch_Y") == 0)
                        {
                            if (GUILayout.Button("�ѹر�", shortButtonStyle))
                            {
                                material.SetFloat("_WPO_CustomSwitch_Y", 1);
                            }

                        }
                        else
                        {
                            if (GUILayout.Button("�ѿ���", shortButtonStyle))
                            {
                                material.SetFloat("_WPO_CustomSwitch_Y", 0);
                            }
                        }
                        EditorGUILayout.EndVertical();

                        m_MaterialEditor.ShaderProperty(WPO_tex_power, "����ƫ��ǿ��");
                        m_MaterialEditor.ShaderProperty(WPO_Tex_Direction, "����ƫ������");
                        EditorGUILayout.EndVertical();

                        EditorGUILayout.BeginVertical(EditorStyles.helpBox);
                        m_MaterialEditor.ShaderProperty(WPO_Tex_U_speed, "���������ٶ�");
                        m_MaterialEditor.ShaderProperty(WPO_Tex_V_speed, "���������ٶ�");
                        EditorGUILayout.EndVertical();

                    }
                }

                EditorGUI.indentLevel--;
            }
            EditorGUILayout.EndVertical();
        }
        else
        {
            EditorGUILayout.BeginVertical(EditorStyles.helpBox);
            _WPO_Foldout = Foldout2(_WPO_Foldout, "����ƫ����ͼ(WPOTexture)");

            if (_WPO_Foldout)
            {
                EditorGUI.indentLevel++;


                {


                    m_MaterialEditor.TexturePropertySingleLine(new GUIContent("����ƫ����ͼ"), WPO_Tex);



                    if (WPO_Tex.textureValue != null)
                    {

                        m_MaterialEditor.TextureScaleOffsetProperty(WPO_Tex);


                        EditorGUILayout.BeginVertical(EditorStyles.helpBox);
                        m_MaterialEditor.ShaderProperty(WPO_Switch, "����ƫ�ƿ���");

                        EditorGUILayout.BeginHorizontal();
                        EditorGUILayout.PrefixLabel("�Զ��嶥��ƫ�ƿ��أ�Y��");

                        if (material.GetFloat("_WPO_CustomSwitch_Y") == 0)
                        {
                            if (GUILayout.Button("�ѹر�", shortButtonStyle))
                            {
                                material.SetFloat("_WPO_CustomSwitch_Y", 1);
                            }

                        }
                        else
                        {
                            if (GUILayout.Button("�ѿ���", shortButtonStyle))
                            {
                                material.SetFloat("_WPO_CustomSwitch_Y", 0);
                            }
                        }
                        EditorGUILayout.EndVertical();

                        m_MaterialEditor.ShaderProperty(WPO_tex_power, "����ƫ��ǿ��");
                        m_MaterialEditor.ShaderProperty(WPO_Tex_Direction, "����ƫ������");
                        EditorGUILayout.EndVertical();

                        EditorGUILayout.BeginVertical(EditorStyles.helpBox);
                        m_MaterialEditor.ShaderProperty(WPO_Tex_U_speed, "���������ٶ�");
                        m_MaterialEditor.ShaderProperty(WPO_Tex_V_speed, "���������ٶ�");
                        EditorGUILayout.EndVertical();

                    }
                }

                EditorGUI.indentLevel--;
            }
            EditorGUILayout.EndVertical();
        }
        #endregion

        //------------------------------------��������----------------------------------------------






    }
}