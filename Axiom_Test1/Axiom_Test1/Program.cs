using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Axiom.Core;
using Axiom.Graphics;
using Axiom.Math;
using Axiom.Framework.Configuration;
using System.Configuration;

namespace Axiom_Test1
{
    class Program
    {
        static void Main()
        {
            IConfigurationManager ConfigurationManager = ConfigurationManagerFactory.CreateDefault();
            using ( var root = new Root( "Game1.log" ) )
            {
                if ( ConfigurationManager.ShowConfigDialog( root ) )
                {
                    RenderWindow window = root.Initialize( true );
                    ResourceGroupManager.Instance.AddResourceLocation( "media", "Folder", true );
                    SceneManager scene = root.CreateSceneManager( SceneType.Generic );
                    Camera camera = scene.CreateCamera( "cam1" );
                    Viewport viewport = window.AddViewport( camera );
                    TextureManager.Instance.DefaultMipmapCount = 5;
                    ResourceGroupManager.Instance.InitializeAllResourceGroups();

                    Light pointLight = scene.CreateLight("pointLight");
                    //pointLight.Type = LightType.Point;
                    //pointLight.Position = new Vector3(0, 150, 250);
                    //pointLight.DiffuseColor = ColorEx.Red;
                    //pointLight.SpecularColor = ColorEx.Red;
                    //pointLight.Diffuse = ColorEx.Red;
                    scene.AmbientLight = new ColorEx(1, 1, 1);

                    //Entity penguin = scene.CreateEntity( "bob", "penguin.mesh" );
                    //SceneNode penguinNode = scene.RootSceneNode.CreateChildSceneNode();
                    //penguinNode.AttachObject( penguin );
                    camera.Move( new Vector3( 0, 0, 300 ) );
                    //camera.LookAt( penguin.BoundingBox.Center );

                    Plane plane = new Plane(Vector3.UnitY, 0);
                    MeshManager.Instance.CreatePlane("ground",
                    ResourceGroupManager.DefaultResourceGroupName, plane, 1500, 1500, 20, 20, true, 1, 5, 5, Vector3.UnitZ);
                    Entity groundEnt = scene.CreateEntity("GroundEntity", "ground");
                    scene.RootSceneNode.CreateChildSceneNode().AttachObject(groundEnt);
                    groundEnt.SetMaterialName("Examples/Rockwall");
                    groundEnt.CastShadows = false;

                    camera.LookAt(groundEnt.BoundingBox.Center);
                    root.RenderOneFrame();
                }
                Console.Write( "Press [Enter] to exit." );
                Console.ReadLine();
            }

        }
    }
}
