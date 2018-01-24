using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Tao.FreeGlut;
using OpenGL;

namespace OpenGL_Test3
{
    class Program
    {
        public static int DefaultWidth = 1200, DefaultHeight = 720, CurrentWidth = 720, CurrentHeight = 1200;
        public static VBO<Vector3> Cube;
        public static VBO<Vector2> CubeUV;
        public static VBO<int> CubeQuads;
        public static System.Diagnostics.Stopwatch watch;
        public static float PosX, PosZ, TurnAngle = 0;

        public static Texture Texture1, Texture2;

        public static List<object> Object_List = new List<object>();
        public static Camera camera;

        public static void Main()
        {
            
            Glut.glutInit();
            Glut.glutInitDisplayMode(Glut.GLUT_DOUBLE | Glut.GLUT_DEPTH);
            Glut.glutInitWindowSize(DefaultWidth, DefaultHeight);
            Glut.glutCreateWindow("OpenGL Toutorial");

            Camera camera = new Camera();

            Glut.glutIdleFunc(OnRenderFrame);
            Glut.glutDisplayFunc(OnDisplay);
            Glut.glutCloseFunc(OnClose);
            Glut.glutKeyboardFunc(OnKeyboardDown);
            Glut.glutKeyboardUpFunc(OnKeyboardUp);
            Glut.glutReshapeFunc(camera.OnReshape);

            Gl.Enable(EnableCap.DepthTest);

            Texture1 = new Texture("Grass1.jpg");
            Cube = new VBO<Vector3>(new Vector3[] {
                new Vector3(1, 1, -1), new Vector3(-1, 1, -1), new Vector3(-1, 1, 1), new Vector3(1, 1, 1), //top
                new Vector3(1, -1, 1), new Vector3(-1, -1, 1), new Vector3(-1, -1, -1), new Vector3(1, -1, -1), //bottom
                new Vector3(1, 1, 1), new Vector3(-1, 1, 1), new Vector3(-1, -1, 1), new Vector3(1, -1, 1), //front face
                new Vector3(1, -1, -1), new Vector3(-1, -1, -1), new Vector3(-1, 1, -1), new Vector3(1, 1, -1), //back face
                new Vector3(-1, 1, 1), new Vector3(-1, 1, -1), new Vector3(-1, -1, -1), new Vector3(-1, -1, 1), //left face
                new Vector3(1, 1, -1), new Vector3(1, 1, 1), new Vector3(1, -1, 1), new Vector3(1, -1, -1) }); //right face
            CubeUV = new VBO<Vector2>(new Vector2[] {
                new Vector2(0, 0), new Vector2(1, 0), new Vector2(1, 1), new Vector2(0, 1), 
                new Vector2(0, 0), new Vector2(1, 0), new Vector2(1, 1), new Vector2(0, 1),
                new Vector2(0, 0), new Vector2(1, 0), new Vector2(1, 1), new Vector2(0, 1),
                new Vector2(0, 0), new Vector2(1, 0), new Vector2(1, 1), new Vector2(0, 1),
                new Vector2(0, 0), new Vector2(1, 0), new Vector2(1, 1), new Vector2(0, 1),
                new Vector2(0, 0), new Vector2(1, 0), new Vector2(1, 1), new Vector2(0, 1) });
            CubeQuads = new VBO<int>(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23 }, BufferTarget.ElementArrayBuffer);

            Glut.glutMainLoop();
        }
        private static void OnClose()
        {
            camera.Shader_Program.DisposeChildren = true;
            camera.Shader_Program.Dispose();
        }

        private static void OnDisplay()
        {

        }

        private static void OnKeyboardDown(byte Key, int x, int y)
        {
        }

        private static void OnKeyboardUp(byte key, int x, int y)
        {

        }


        private static void OnRenderFrame()
        {
            //Gl.UseProgram(camera.Shader_Program);
            camera.ModelTranslate(0, 0, 0);
            Gl.BindBufferToShaderAttribute(Cube, camera.Shader_Program, "vertexPosition");
            Gl.BindBufferToShaderAttribute(CubeUV, camera.Shader_Program, "vertexUV");
            Gl.BindBuffer(CubeQuads);
            //camera.Bind(Cube, CubeUV, camera.Shader_Program, "vertexPosition", "vertexUV", CubeQuads);

            Gl.DrawElements(BeginMode.Quads, CubeQuads.Count, DrawElementsType.UnsignedInt, IntPtr.Zero);
        }
    }

    class Camera
    {
        public ShaderProgram Shader_Program;
        public int CurrentWidth;
        public int CurrentHeight;

        public Camera()
        {
            Shader_Program = new ShaderProgram(VertexShader, FragmentShader);
            Shader_Program.Use();
            Shader_Program["projection_matrix"].SetValue(Matrix4.CreatePerspectiveFieldOfView(0.45f, (float)CurrentHeight / CurrentHeight, 0.1f, 1000f));
            Shader_Program["view_matrix"].SetValue(Matrix4.LookAt(new Vector3(0, 0, 10), Vector3.Zero, Vector3.Up));

        }

        public void OnReshape(int width, int height)
        {
            CurrentWidth = width;
            CurrentHeight = height;

            Shader_Program.Use();
            Shader_Program["projection_matrix"].SetValue(Matrix4.CreatePerspectiveFieldOfView(0.45f, (float)CurrentWidth / CurrentHeight, 0.1f, 1000f));

        }

        public void ModelTranslate(float X, float Y, float Z)
        {
            Shader_Program["model_matrix"].SetValue(Matrix4.CreateTranslation(new Vector3(X, Y, Z)));
        }

        public void Bind(VBO<Vector3> buffer1, VBO<Vector3> buffer2, ShaderProgram ShaderProgram, string Attribute, string Attribute2, VBO<Vector3> Buffer3)
        {
            Gl.BindBufferToShaderAttribute(buffer1, ShaderProgram, Attribute);
            Gl.BindBufferToShaderAttribute(buffer2, ShaderProgram, Attribute2);
            Gl.BindBuffer(Buffer3);
        }

        public string VertexShader = @"
in vec3 vertexPosition;
in vec2 vertexUV;

out vec2 uv;

uniform mat4 projection_matrix;
uniform mat4 view_matrix;
uniform mat4 model_matrix;

void main(void)
{
    uv = vertexUV;
    gl_Position = projection_matrix * view_matrix * model_matrix * vec4(vertexPosition, 1);
}
";

        public string FragmentShader = @"

uniform sampler2D texture;

in vec2 uv;

out vec4 fragment;

void main(void)
{
    fragment = texture2D(texture, uv);
}
";
    }
}
