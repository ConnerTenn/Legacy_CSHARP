using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tao.FreeGlut;
using OpenGL;

namespace Object_Test
{
    class ball
    {
        public int Value = 1;
        public int Value2 = 2;
        public VBO<Vector3> Cube;
        public VBO<Vector2> CubeUV;
        public VBO<int> CubeQuads;
        //public Texture CubeTexture;
        public int x1, y1, z1, x2, y2, z2;

        public ball(int x1in, int y1in, int z1in, int x2in, int y2in, int z2in)
        {
            x1 = x1in; y1 = y1in; z1 = z1in;
            x2 = x2in; y2 = y2in; z2 = z2in;
            /*Cube = new VBO<Vector3>(new Vector3[] {
                new Vector3(1, 1, -1), new Vector3(-1, 1, -1), new Vector3(-1, 1, 1), new Vector3(1, 1, 1), //top
                new Vector3(1, -1, 1), new Vector3(-1, -1, 1), new Vector3(-1, -1, -1), new Vector3(1, -1, -1), //bottom
                new Vector3(1, 1, 1), new Vector3(-1, 1, 1), new Vector3(-1, -1, 1), new Vector3(1, -1, 1), //front face
                new Vector3(1, -1, -1), new Vector3(-1, -1, -1), new Vector3(-1, 1, -1), new Vector3(1, 1, -1), //back face
                new Vector3(-1, 1, 1), new Vector3(-1, 1, -1), new Vector3(-1, -1, -1), new Vector3(-1, -1, 1), //left face
                new Vector3(1, 1, -1), new Vector3(1, 1, 1), new Vector3(1, -1, 1), new Vector3(1, -1, -1) }); //right face */
            Cube = new VBO<Vector3>(new Vector3[] {
                new Vector3(x1in, y1in, z2in), new Vector3(x2in, y1in, z2in), new Vector3(x2in, y1in, z1in), new Vector3(x1in, y1in, z1in), //top
                new Vector3(x1in, y2in, z1in), new Vector3(x2in, y2in, z1in), new Vector3(x2in, y2in, z2in), new Vector3(x1in, y2in, z2in), //bottom
                new Vector3(x1in, y1in, z1in), new Vector3(x2in, y1in, z1in), new Vector3(x2in, y2in, z1in), new Vector3(x1in,y2in, z1in), //front face
                new Vector3(x1in, y2in, z2in), new Vector3(x2in, y2in, z2in), new Vector3(x2in, y1in, z2in), new Vector3(x1in, y1in, z2in), //back face
                new Vector3(x2in, y1in, z1in), new Vector3(x2in, y1in, z2in), new Vector3(x2in, y2in, z2in), new Vector3(x2in, y2in, z1in), //left face
                new Vector3(x1in, y1in, z2in), new Vector3(x1in, y1in, z1in), new Vector3(x1in, y2in, z1in), new Vector3(x1in, y2in, z2in) }); //right face
            CubeUV = new VBO<Vector2>(new Vector2[] {
                new Vector2(0, 0), new Vector2(1, 0), new Vector2(1, 1), new Vector2(0, 1), 
                new Vector2(0, 0), new Vector2(1, 0), new Vector2(1, 1), new Vector2(0, 1),
                new Vector2(0, 0), new Vector2(1, 0), new Vector2(1, 1), new Vector2(0, 1),
                new Vector2(0, 0), new Vector2(1, 0), new Vector2(1, 1), new Vector2(0, 1),
                new Vector2(0, 0), new Vector2(1, 0), new Vector2(1, 1), new Vector2(0, 1),
                new Vector2(0, 0), new Vector2(1, 0), new Vector2(1, 1), new Vector2(0, 1) });
            CubeQuads = new VBO<int>(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23 }, BufferTarget.ElementArrayBuffer);
        }
        
        public void init(int value, int value2)
        {
            Value = value;
            Value2 = value2;
        }

        public void print(string text)
        {
            Console.WriteLine(text);
        }
    }
}
