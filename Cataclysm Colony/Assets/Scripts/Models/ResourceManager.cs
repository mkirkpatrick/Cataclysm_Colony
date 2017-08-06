using System.Collections;
using System.Collections.Generic;

[ System.Serializable ]
public class ResourceManager {

    public enum ResourceType { Energy, Metal}

    public float energy;
    public float metal;


    public bool IsResourceAvailable( ResourceType resourceType, float amount) {

        bool result = false;

        if (resourceType == ResourceType.Energy)
        {
            if (energy >= amount)
                result = true;
        }
        else if (resourceType == ResourceType.Metal) {
            if (metal >= amount)
                result = true;
        }

        return result;
    }
}
