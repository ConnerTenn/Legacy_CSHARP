using System;
using Tao.FreeGlut;
using OpenGL;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Net;
using Microsoft.CSharp;
using System.CodeDom.Compiler;


namespace OpenGL_Test1__Ground_and_Box_
{
    class Program
    {

        private static int DefaultWidth = 1200, DefaultHeight = 720, CurrentWidth = 720, CurrentHeight = 1200;
        private static ShaderProgram Shader_Program;
        private static VBO<Vector3> Cube;
        private static VBO<Vector2> CubeUV;
        private static VBO<int> CubeQuads;
        private static System.Diagnostics.Stopwatch watch;
        private static float PosX, PosZ, TurnAngle = 0;
        
        private static Texture Texture1, Texture2;

        private static List<object> Object_List = new List<object>();


        private static BoxObject Floor = new BoxObject(50,-2,50,-50,-20,-50);
        private static BoxObject Box = new BoxObject(1, 1, 1, -1, -2, -1);
        
        public static void Main()
        {
            Console.WriteLine(Math.Cos(DegRad(90)));
            Glut.glutInit();
            Glut.glutInitDisplayMode(Glut.GLUT_DOUBLE | Glut.GLUT_DEPTH);
            Glut.glutInitWindowSize(DefaultWidth, DefaultHeight);
            Glut.glutCreateWindow("OpenGL Toutorial");

            Glut.glutIdleFunc(OnRenderFrame);
            Glut.glutDisplayFunc(OnDisplay);
            Glut.glutCloseFunc(OnClose);
            Glut.glutKeyboardFunc(OnKeyboardDown);
            Glut.glutKeyboardUpFunc(OnKeyboardUp);
            Glut.glutReshapeFunc(OnReshape);

            Floor.DefObject();
            Object_List.Add(Floor);
            Box.DefObject();
            Object_List.Add(Box);

            Gl.Enable(EnableCap.DepthTest);

            Shader_Program = new ShaderProgram(VertexShader, FragmentShader);

            Shader_Program.Use();
            Shader_Program["projection_matrix"].SetValue(Matrix4.CreatePerspectiveFieldOfView(0.45f, (float)CurrentHeight / CurrentHeight, 0.1f, 1000f));
            Shader_Program["view_matrix"].SetValue(Matrix4.LookAt(new Vector3(0, 0, 10), Vector3.Zero, Vector3.Up));

            Texture1 = new Texture("Grass1.jpg");
            Texture2 = new Texture("Grass2.jpg");

            /*Cube = new VBO<Vector3>(new Vector3[] {
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
            CubeQuads = new VBO<int>(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23 }, BufferTarget.ElementArrayBuffer);*/

            watch = System.Diagnostics.Stopwatch.StartNew();

            Glut.glutMainLoop();
        }
        private static void OnClose()
        {
            Shader_Program.DisposeChildren = true;
            Shader_Program.Dispose();
        }

        private static void OnDisplay()
        {

        }

        private static void OnKeyboardDown(byte Key, int x, int y)
        {
            if (Key == 'w') { PosX -= RadDeg((float)Math.Sin(DegRad(TurnAngle))) * 1; PosZ -= RadDeg((float)Math.Cos(DegRad(TurnAngle))) * 1; }
            if (Key == 's') { PosX += RadDeg((float)Math.Sin(DegRad(TurnAngle))) * 1; PosZ += RadDeg((float)Math.Cos(DegRad(TurnAngle))) * 1; }

            if (Key == 'a') { TurnAngle -= 1; }
            if (Key == 'd') { TurnAngle += 1; }

            Console.WriteLine("X = {0}, Z = {1},   TurnAngle = {2},    LookAt X = {3}, LookAt Z = {4}", PosX, PosZ, TurnAngle, PosX + Math.Sin(TurnAngle), PosZ + Math.Cos(TurnAngle));
            
            Console.WriteLine();
        }

        private static void OnKeyboardUp(byte key, int x, int y)
        {
            
        }

        private static void OnReshape(int width, int height)
        {
            Program.CurrentWidth = width;
            Program.CurrentHeight = height;

            Shader_Program.Use();
            Shader_Program["projection_matrix"].SetValue(Matrix4.CreatePerspectiveFieldOfView(0.45f, (float)CurrentWidth / CurrentHeight, 0.1f, 1000f));
   
        }

        private static float DegRad(float num)
        {
            return (num / (180 / (float)Math.PI));
        }
        private static float PiDegRad(float num)
        {
            return (num / (180 / (float)Math.PI)) * (float)Math.PI;
        }
        private static float RadDeg(float num)
        {
            return (num * (180 / (float)Math.PI));
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

        private static void OnRenderFrame()
        {
            watch.Stop();
            float DeltaTime = (float)watch.ElapsedTicks / (System.Diagnostics.Stopwatch.Frequency );
            watch.Restart();


            Shader_Program["view_matrix"].SetValue(Matrix4.LookAt(new Vector3(PosX, 0, PosZ), new Vector3(PosX + Math.Sin(TurnAngle), 0, PosZ + Math.Cos(TurnAngle)), Vector3.Up));

            Gl.Viewport(0, 0, CurrentWidth, CurrentHeight);
            Gl.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            Gl.UseProgram(Shader_Program);
            Gl.BindTexture(Texture1);

            /*
            foreach (var Objects in Object_List)
            {
                
                Shader_Program["model_matrix"].SetValue(Matrix4.CreateTranslation(new Vector3(0, 0, 0)));
                Gl.BindBufferToShaderAttribute(Objects.Cube, Shader_Program, "vertexPosition");
                Gl.BindBufferToShaderAttribute(Objects.CubeUV, Shader_Program, "vertexUV");
                Gl.BindBuffer(Objects.CubeQuads);

                Gl.DrawElements(BeginMode.Quads, Objects.CubeQuads.Count, DrawElementsType.UnsignedInt, IntPtr.Zero);
            }*/
            Shader_Program["model_matrix"].SetValue(Matrix4.CreateTranslation(new Vector3(0, 0, 0)));
            Gl.BindBufferToShaderAttribute(Floor.Cube, Shader_Program, "vertexPosition");
            Gl.BindBufferToShaderAttribute(Floor.CubeUV, Shader_Program, "vertexUV");
            Gl.BindBuffer(Floor.CubeQuads);

            Gl.DrawElements(BeginMode.Quads, Floor.CubeQuads.Count, DrawElementsType.UnsignedInt, IntPtr.Zero);

            Gl.BindTexture(Texture2);

            Shader_Program["model_matrix"].SetValue(Matrix4.CreateTranslation(new Vector3(0, 0, 0)));
            Gl.BindBufferToShaderAttribute(Box.Cube, Shader_Program, "vertexPosition");
            Gl.BindBufferToShaderAttribute(Box.CubeUV, Shader_Program, "vertexUV");
            Gl.BindBuffer(Box.CubeQuads);

            Gl.DrawElements(BeginMode.Quads, Box.CubeQuads.Count, DrawElementsType.UnsignedInt, IntPtr.Zero);

            // draw my cube
            //Shader_Program["model_matrix"].SetValue(Matrix4.CreateRotationX(xangle) * Matrix4.CreateRotationY(yangle) * Matrix4.CreateRotationZ(zangle));
            /*Shader_Program["model_matrix"].SetValue(Matrix4.CreateTranslation(new Vector3(0,0,0)));
            Gl.BindBufferToShaderAttribute(Floor.Cube, Shader_Program, "vertexPosition");
            Gl.BindBufferToShaderAttribute(Floor.CubeUV, Shader_Program, "vertexUV");
            Gl.BindBuffer(Floor.CubeQuads);
            
            Gl.DrawElements(BeginMode.Quads, Floor.CubeQuads.Count, DrawElementsType.UnsignedInt, IntPtr.Zero);
            */


            Glut.glutSwapBuffers();
        }
    }
}
