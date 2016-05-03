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
            XmlNode element = doc.SelectSingleNode("//settings/tiles");
            Tiles.tileSize = getInt(element, "size");
            //load world's width and height
            element = doc.SelectSingleNode("//settings/world");
            World.width = getInt(element, "width");
            World.height = getInt(element, "height");
            //load camera's speed
            element = doc.SelectSingleNode("//settings/camera");
            Camera.lowSpeed = getInt(element, "lowSpeed");
            Camera.highSpeed = getInt(element,"highSpeed");
        }

        public static void load()
        {
            load("Settings/settings.xml");
        }

        private static Int32 getInt(XmlNode element, String name)
        {
            XmlNode nextNode = element.SelectSingleNode(name);
            return Convert.ToInt32(nextNode.LastChild.Value);
        }

    }
}
