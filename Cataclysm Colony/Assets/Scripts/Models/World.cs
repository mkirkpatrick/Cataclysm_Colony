using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ System.Serializable ]
public class World {

   // [ System.NonSerialized ]
    public Base baseData;

    public int width;
    public int height;

    public World(int w, int h) {

        width = w;
        height = h;

        baseData = new Base(100);

    }
    public World() { }
}
