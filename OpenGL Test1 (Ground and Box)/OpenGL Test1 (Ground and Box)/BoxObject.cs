using System;
using Tao.FreeGlut;
using OpenGL;

namespace OpenGL_Test1__Ground_and_Box_
{
    public class BoxObject
    {
        public VBO<Vector3> Cube;
        public VBO<Vector2> CubeUV;
        public VBO<int> CubeQuads;
        //public Texture CubeTexture;
        public int x1, y1, z1, x2, y2, z2;

        public BoxObject(int x1in, int y1in, int z1in, int x2in, int y2in, int z2in)
        {
            x1 = x1in; y1 = y1in; z1 = z1in;
            x2 = x2in; y2 = y2in; z2 = z2in;
            /*Cube = new VBO<Vector3>(new Vector3[] {
                new Vector3(1, 1, -1), new Vector3(-1, 1, -1), new Vector3(-1, 1, 1), new Vector3(1, 1, 1), //top
                new Vector3(1, -1, 1), new Vector3(-1, -1, 1), new Vector3(-1, -1, -1), new Vector3(1, -1, -1), //bottom
                new Vector3(1, 1, 1), new Vector3(-1, 1, 1), new Vector3(-1, -1, 1), new Vector3(1, -1, 1), //front face
                new Vector3(1, -1, -1), new Vector3(-1, -1, -1), new Vector3(-1, 1, -1), new Vector3(1, 1, -1), //back face
                new Vector3(-1, 1, 1), new Vector3(-1, 1, -1), new Vector3(-1, -1, -1), new Vector3(-1, -1, 1), //left face
                new Vector3(1, 1, -1), new Vector3(1, 1, 1), new Vector3(1, -1, 1), new Vector3(1, -1, -1) }); //right face 
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
            */
        }

        public void DefObject()
        {
            /*Cube = new VBO<Vector3>(new Vector3[] {
                new Vector3(1, 1, -1), new Vector3(-1, 1, -1), new Vector3(-1, 1, 1), new Vector3(1, 1, 1), //top
                new Vector3(1, -1, 1), new Vector3(-1, -1, 1), new Vector3(-1, -1, -1), new Vector3(1, -1, -1), //bottom
                new Vector3(1, 1, 1), new Vector3(-1, 1, 1), new Vector3(-1, -1, 1), new Vector3(1, -1, 1), //front face
                new Vector3(1, -1, -1), new Vector3(-1, -1, -1), new Vector3(-1, 1, -1), new Vector3(1, 1, -1), //back face
                new Vector3(-1, 1, 1), new Vector3(-1, 1, -1), new Vector3(-1, -1, -1), new Vector3(-1, -1, 1), //left face
                new Vector3(1, 1, -1), new Vector3(1, 1, 1), new Vector3(1, -1, 1), new Vector3(1, -1, -1) }); //right face */
            Cube = new VBO<Vector3>(new Vector3[] {
                new Vector3(x1, y1, z2), new Vector3(x2, y1, z2), new Vector3(x2, y1, z1), new Vector3(x1, y1, z1), //top
                new Vector3(x1, y2, z1), new Vector3(x2, y2, z1), new Vector3(x2, y2, z2), new Vector3(x1, y2, z2), //bottom
                new Vector3(x1, y1, z1), new Vector3(x2, y1, z1), new Vector3(x2, y2, z1), new Vector3(x1, y2, z1), //front face
                new Vector3(x1, y2, z2), new Vector3(x2, y2, z2), new Vector3(x2, y1, z2), new Vector3(x1, y1, z2), //back face
                new Vector3(x2, y1, z1), new Vector3(x2, y1, z2), new Vector3(x2, y2, z2), new Vector3(x2, y2, z1), //left face
                new Vector3(x1, y1, z2), new Vector3(x1, y1, z1), new Vector3(x1, y2, z1), new Vector3(x1, y2, z2) }); //right face
            CubeUV = new VBO<Vector2>(new Vector2[] {
                new Vector2(0, 0), new Vector2(1, 0), new Vector2(1, 1), new Vector2(0, 1), 
                new Vector2(0, 0), new Vector2(1, 0), new Vector2(1, 1), new Vector2(0, 1),
                new Vector2(0, 0), new Vector2(1, 0), new Vector2(1, 1), new Vector2(0, 1),
                new Vector2(0, 0), new Vector2(1, 0), new Vector2(1, 1), new Vector2(0, 1),
                new Vector2(0, 0), new Vector2(1, 0), new Vector2(1, 1), new Vector2(0, 1),
                new Vector2(0, 0), new Vector2(1, 0), new Vector2(1, 1), new Vector2(0, 1) });
            CubeQuads = new VBO<int>(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23 }, BufferTarget.ElementArrayBuffer);

        }
    }
}
