using System;
using System.Collections.Generic;

public class Model
{
    private string modelName;

    public Model(string modelName)
    {
        this.modelName = modelName;
    }

    public string ModelName
    {
        get
        {
            return this.modelName;
        }
        set
        {
            this.modelName = value;
        }
    }
}