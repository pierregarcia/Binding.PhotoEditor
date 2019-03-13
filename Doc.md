Rejecting re-init on previously-failed class java.lang.Class<ly.img.android.pesdk.backend.text_design.layout.TextDesign$fonts$2>: java.lang.NoClassDefFoundError: Failed resolution of: Lkotlin/jvm/internal/Lambda;
Add Xamarin.Kotlin.StdLib.Jdk7 int the Startup project and in the library using Kotlin

Error CS0534: 'CropViewHolder' does not implement inherited abstract member 'DataSourceListAdapter.DataSourceViewHolder.BindData(Object)'
<attr path="/api/package[@name='ly.img.android.pesdk.ui.viewholder']/class[@name='CropViewHolder']/method[@name='bindData']/parameter[1]" name="type">java.lang.Object</attr>
public partial class CropViewHolder
{
    protected override void BindData(Java.Lang.Object item)
    {
        this.BindData(item as LY.Img.Android.Pesdk.UI.Panels.Item.CropAspectItem);
    }
}

Error CS0535: 'TransformToolPanel' does not implement interface member 'DataSourceListAdapter.IOnItemClickListener.OnItemClick(Object)
<attr path="/api/package[@name='ly.img.android.pesdk.ui.panels']/class[@name='TransformToolPanel']/method[@name='onItemClick']/parameter[1]" name="type">java.lang.Object</attr>
public partial class TransformToolPanel
{
    public void OnItemClick(Java.Lang.Object entity)
    {
        OnItemClick(entity as LY.Img.Android.Pesdk.UI.Panels.Item.CropAspectItem); 
    }
}

Error CS0535: 'BrushToolPanel' does not implement interface member 'TimeOut.ICallback.OnTimeOut(Object)' (CS0535) (PhotoEditor.Android.Mobile.UI.Brush.Binding)

Error CS0111: Type 'UiConfigAspect' already defines a member called 'SetAspectList' with the same parameter types (CS0111)
In this case, multiple methods takes an ArrayList<object> or an array (object[]) as parameter. 
In the binding, ine case of an ArrayList<object> it will create an IList<object>
Two choices :
if the methods are doing the same thing, remove one of them
<remove-node path="/api/package[@name='ly.img.android.pesdk.ui.model.state']/class[@name='UiConfigAspect']/method[@name='setAspectList' and count(parameter)=1 and parameter[1][@type='java.util.ArrayList&lt;ly.img.android.pesdk.ui.panels.item.CropAspectItem&gt;...']]"/>

