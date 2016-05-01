using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Citysim
{
    class Setting
    {

        public class Tiles
        {
            public static int tileSize;
        }

        public class World
        {
            public static int width;
            public static int height;
        }

        public class Camera
        {
            public static int lowSpeed;
            public static int highSpeed;
        }

        public static void load(String xml)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(xml);
            //load tile's size
            XmlNode element = doc.SelectSingleNode("//settings/tiles/size");
            Tiles.tileSize = Convert.ToInt32(element.LastChild.Value);
            //load world's width and height
            element = doc.SelectSingleNode("//settings/world");
            XmlNode nextElement = element.SelectSingleNode("width");
            World.width = Convert.ToInt32(nextElement.LastChild.Value);
            nextElement = element.SelectSingleNode("height");
            World.height = Convert.ToInt32(nextElement.LastChild.Value);
            //load camera's speed
            element = doc.SelectSingleNode("//settings/camera");
            nextElement = element.SelectSingleNode("lowSpeed");
            Camera.lowSpeed = Convert.ToInt32(nextElement.LastChild.Value);
            nextElement = element.SelectSingleNode("highSpeed");
            Camera.highSpeed = Convert.ToInt32(nextElement.LastChild.Value);
        }

        public static void load()
        {
            load("Settings/settings.xml");
        }

    }
}
