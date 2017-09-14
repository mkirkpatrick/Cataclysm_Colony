using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ System.Serializable ]
public class World {

    public int width;
    public int height;

    public World(int w, int h) {

        width = w;
        height = h;

    }
    public World() { }
}
