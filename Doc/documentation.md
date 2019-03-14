- **Rejecting re-init on previously-failed class : java.lang.NoClassDefFoundError: Failed resolution of: Lkotlin/jvm/internal/Lambda;**   
Add Xamarin.Kotlin.StdLib.Jdk7 int the Startup project and in the library using Kotlin

- **Error CS0534: 'CropViewHolder' does not implement inherited abstract member 'DataSourceListAdapter.DataSourceViewHolder.BindData(Object)'**
```csharp
<attr path="/api/package[@name='ly.img.android.pesdk.ui.viewholder']/class[@name='CropViewHolder']/method[@name='bindData']/parameter[1]" name="type">java.lang.Object</attr>
public partial class CropViewHolder
{
    protected override void BindData(Java.Lang.Object item)
    {
        this.BindData(item as LY.Img.Android.Pesdk.UI.Panels.Item.CropAspectItem);
    }
}
```

- **Error CS0535: 'TransformToolPanel' does not implement interface member 'DataSourceListAdapter.IOnItemClickListener.OnItemClick(Object)**
```csharp
<attr path="/api/package[@name='ly.img.android.pesdk.ui.panels']/class[@name='TransformToolPanel']/method[@name='onItemClick']/parameter[1]" name="type">java.lang.Object</attr>
public partial class TransformToolPanel
{
    public void OnItemClick(Java.Lang.Object entity)
    {
        OnItemClick(entity as LY.Img.Android.Pesdk.UI.Panels.Item.CropAspectItem); 
    }
}
```

- **Error CS0535: 'BrushToolPanel' does not implement interface member 'TimeOut.ICallback.OnTimeOut(Object)'**   
Sometimes, a method is not overrided in the class. We have to add it. You have two choices
```csharp
//Create a new class in the Additions folder
public partial class BrushToolPanel
{
    public void OnTimeOut(Java.Lang.Object entity)
    {
    }
}

//OR
//add the new method in the `Metadata.xml`

<add-node path="/api/package[@name='ly.img.android.pesdk.ui.panels']/class[@name='BrushToolPanel']">
        <method name="OnTimeOut" return="void" abstract="false" native="false" synchronized="false" static="false" final="false" deprecated="not deprecated" visibility="public">
            <parameter name="entity" type="java.lang.Object" />
        </method>
</add-node>
```

- **Error CS0111: Type 'UiConfigAspect' already defines a member called 'SetAspectList' with the same parameter types (CS0111)**   
In this case, in the java caode, there are 3 methods `setAspectList`;
```java
public void setAspectList(ArrayList<CropAspectItem>... aspectLists);
public void setAspectList(ArrayList<CropAspectItem> aspectList);
public void setAspectList(CropAspectItem... aspectList);
```

When binding, the first two will generate two methods:
```csharp
public void SetAspectList(IList<CropAspectItem> aspectLists);
public void SetAspectList(IList<CropAspectItem> aspectLists);
```
So we have to remove one of them (in this case the first one):
```xml
<remove-node path="/api/package[@name='ly.img.android.pesdk.ui.model.state']/class[@name='UiConfigAspect']/method[@name='setAspectList' and count(parameter)=1 and parameter[1][@type='java.util.ArrayList&lt;ly.img.android.pesdk.ui.panels.item.CropAspectItem&gt;...']]"/>
```

- ***Error CS0115: 'ColorOptionBrushToolPanel.SetColor(int)': no suitable method found to override || error CS0534: 'ColorOptionBrushToolPanel' does not implement inherited abstract member 'ColorOptionToolPanel.Color.set'***   
In Xamarin binding, when you have two java methods `getColor/setColor(Color color)` for a property, it will create a C# property `Color{get;set;}`   
If you want to force the binding to keep the two methods, set the `propertyName` to an empty string:
```xml 
    <attr path="/api/package[@name='ly.img.android.pesdk.ui.panels']/class[@name='ColorOptionToolPanel']/method[@name='setColor' and count(parameter)=1 and parameter[1][@type='int']]" name="propertyName"></attr>

    <attr path="/api/package[@name='ly.img.android.pesdk.ui.panels']/class[@name='ColorOptionToolPanel']/method[@name='getColor' and count(parameter)=0]" name= "propertyName"></attr>
```

- ***Warning BG8800: Unknown parameter type System.Xml.XmlReader in method CreateFromXml in managed type Android.Content.Res.ColorStateList.***   
  Add a reference in the binding project to `System.Xml`

**ANDROID SETUP**

- Incluse the all the Release DLLs in the Android Project and Add them as reference
- In `Android Properties`, enable `MultiDex`
- Include all the [Styles](styles.xml) in Resources
- Add the [strings](strings.xml) in the resources.rsw