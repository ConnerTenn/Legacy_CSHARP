using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tao.FreeGlut;
using OpenGL;

namespace OpenGL_Toutorial2
{
    class Program
    {
        private static int width = 1200, height = 720;
        private static ShaderProgram ShaderProgram;
        private static VBO<Vector3> cube;
        private static VBO<Vector2> cubeUV;
        private static VBO<int> cubeQuads;
        private static Texture CrateTexture;
        private static float move = 0;

        private static System.Diagnostics.Stopwatch watch;
        private static float angle;

        static void Main()
        {
            Glut.glutInit();
            Glut.glutInitDisplayMode(Glut.GLUT_DOUBLE | Glut.GLUT_DEPTH);
            Glut.glutInitWindowSize(width, height);
            Glut.glutCreateWindow("OpenGL Toutorial");

            Glut.glutIdleFunc(OnRenderFrame);
            Glut.glutDisplayFunc(OnDisplay);
            Glut.glutCloseFunc(OnClose);

            Gl.Enable(EnableCap.DepthTest);

            ShaderProgram = new ShaderProgram(VertexShader, FragmentShader);

            ShaderProgram.Use();
            ShaderProgram["projection_matrix"].SetValue(Matrix4.CreatePerspectiveFieldOfView(0.45f, (float)width / height, 0.1f, 1000f));
            ShaderProgram["view_matrix"].SetValue(Matrix4.LookAt(new Vector3(0, 0, 10), Vector3.Zero, Vector3.Up));

            CrateTexture = new Texture("Grass1.jpg");

            cube = new VBO<Vector3>(new Vector3[] {
                new Vector3(1, 1, -1), new Vector3(-1, 1, -1), new Vector3(-1, 1, 1), new Vector3(1, 1, 1),
                new Vector3(1, -1, 1), new Vector3(-1, -1, 1), new Vector3(-1, -1, -1), new Vector3(1, -1, -1),
                new Vector3(1, 1, 1), new Vector3(-1, 1, 1), new Vector3(-1, -1, 1), new Vector3(1, -1, 1),
                new Vector3(1, -1, -1), new Vector3(-1, -1, -1), new Vector3(-1, 1, -1), new Vector3(1, 1, -1),
                new Vector3(-1, 1, 1), new Vector3(-1, 1, -1), new Vector3(-1, -1, -1), new Vector3(-1, -1, 1),
                new Vector3(1, 1, -1), new Vector3(1, 1, 1), new Vector3(1, -1, 1), new Vector3(1, -1, -1) });
            int x1 = 500; int y1 = -5; int z1 = 10;
            int x2 = -500; int y2 = -50; int z2 = -1000;
            cube = new VBO<Vector3>(new Vector3[] {
                new Vector3(x1, y1, z2), new Vector3(x2, y1, z2), new Vector3(x2, y1, z1), new Vector3(x1, y1, z1), //top
                new Vector3(x1, y2, z1), new Vector3(x2, y2, z1), new Vector3(x2, y2, z2), new Vector3(x1, y2, z2), //bottom
                new Vector3(x1, y1, z1), new Vector3(x2, y1, z1), new Vector3(x2, y2, z1), new Vector3(x1,y2, z1), //front face
                new Vector3(x1, y2, z2), new Vector3(x2, y2, z2), new Vector3(x2, y1, z2), new Vector3(x1, y1, z2), //back face
                new Vector3(x2, y1, z1), new Vector3(x2, y1, z2), new Vector3(x2, y2, z2), new Vector3(x2, y2, z1), //left face
                new Vector3(x1, y1, z2), new Vector3(x1, y1, z1), new Vector3(x1, y2, z1), new Vector3(x1, y2, z2) }); //right face
            cubeUV = new VBO<Vector2>(new Vector2[] {
                new Vector2(0, 0), new Vector2(1, 0), new Vector2(1, 1), new Vector2(0, 1), 
                new Vector2(0, 0), new Vector2(1, 0), new Vector2(1, 1), new Vector2(0, 1),
                new Vector2(0, 0), new Vector2(1, 0), new Vector2(1, 1), new Vector2(0, 1),
                new Vector2(0, 0), new Vector2(1, 0), new Vector2(1, 1), new Vector2(0, 1),
                new Vector2(0, 0), new Vector2(1, 0), new Vector2(1, 1), new Vector2(0, 1),
                new Vector2(0, 0), new Vector2(1, 0), new Vector2(1, 1), new Vector2(0, 1) });
            cubeQuads = new VBO<int>(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23 }, BufferTarget.ElementArrayBuffer);

            watch = System.Diagnostics.Stopwatch.StartNew();

            Glut.glutMainLoop();
        }

        private static void OnClose()
        {
            cube.Dispose();
            cubeUV.Dispose();
            cubeQuads.Dispose();
            CrateTexture.Dispose();
            ShaderProgram.DisposeChildren = true;
            ShaderProgram.Dispose();
        }

        private static void OnDisplay()
        {

        }

        private static void OnRenderFrame()
        {
            watch.Stop();
            float DeltaTime = (float)watch.ElapsedTicks / System.Diagnostics.Stopwatch.Frequency;
            watch.Restart();

            angle += DeltaTime;

            ShaderProgram["projection_matrix"].SetValue(Matrix4.CreatePerspectiveFieldOfView(0.45f, (float)width / height, 0.1f, 1000f));
            ShaderProgram["view_matrix"].SetValue(Matrix4.LookAt(new Vector3(0, 0, 10), new Vector3(0, move / 500, 0), Vector3.Up));

            Gl.Viewport(0, 0, width, height);
            Gl.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            Gl.UseProgram(ShaderProgram);
            Gl.BindTexture(CrateTexture);

            // draw my cube
            move += DeltaTime * 100;
            ShaderProgram["model_matrix"].SetValue(Matrix4.CreateTranslation(new Vector3(0, 0, move)));
            Gl.BindBufferToShaderAttribute(cube, ShaderProgram, "vertexPosition");
            Gl.BindBufferToShaderAttribute(cubeUV, ShaderProgram, "vertexUV");
            Gl.BindBuffer(cubeQuads);

            Gl.DrawElements(BeginMode.Quads, cubeQuads.Count, DrawElementsType.UnsignedInt, IntPtr.Zero);

            Glut.glutSwapBuffers();
        }

        public static string VertexShader = @"
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

        public static string FragmentShader = @"

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
