using System;
using DevExpress.Xpo;
using System.Drawing;

public class MyObject : XPObject {
    public MyObject()
        : base() { }

    public MyObject(Session session)
        : base(session) { }

    public override void AfterConstruction() {
        base.AfterConstruction();
    }

    protected String _Title;
    public String Title {
        get { return _Title; }
        set { SetPropertyValue<String>("Title", ref _Title, value); }
    }

    private String _DxColor;
    public String DxColor {
        get { return _DxColor; }
        set { SetPropertyValue<String>("DxColor", ref _DxColor, value); }
    }
}

