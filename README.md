# BindingToInvalidObject
Click "Create Person"
This creates a PersonViewModel and passes it to a new PersonPage.
PersonPage is then bound to the PersonViewModel object.
By clicking the Delete toolbar item, the PersonViewModel gets flagged as deleted.
Navigation.PopModalAsync gets called and then the page should close.
But in fact during the PopModalAsync, it ends up calling bound properties on the PersonViewModel object!
My properties will throw an error as the object is marked as deleted.

This did not cause an error in Xamarin (3.5), but now causes the following:

System.Reflection.TargetInvocationException
Exception has been thrown by the target of an invocation.

   at System.Reflection.MethodBaseInvoker.InvokeWithNoArgs(Object obj, BindingFlags invokeAttr)
   at System.Reflection.RuntimeMethodInfo.Invoke(Object obj, BindingFlags invokeAttr, Binder binder, Object[] parameters, CultureInfo culture)
   at System.Reflection.MethodBase.Invoke(Object obj, Object[] parameters)
   at Microsoft.Maui.Controls.BindingExpression.BindingExpressionPart.TryGetValue(Object source, Object& value)
   at Microsoft.Maui.Controls.BindingExpression.ApplyCore(Object sourceObject, BindableObject target, BindableProperty property, Boolean fromTarget, SetterSpecificity specificity)
   at Microsoft.Maui.Controls.BindingExpression.Apply(Boolean fromTarget)
   at Microsoft.Maui.Controls.Binding.Apply(Boolean fromTarget)
   at Microsoft.Maui.Controls.BindableObjectExtensions.RefreshPropertyValue(BindableObject self, BindableProperty property, Object value)
   at Microsoft.Maui.Controls.VisualElement.Microsoft.Maui.Controls.IPropertyPropagationController.PropagatePropertyChanged(String propertyName)
   at Microsoft.Maui.Controls.Internals.PropertyPropagationExtensions.PropagatePropertyChanged(String propertyName, Element element, IEnumerable children)
   at Microsoft.Maui.Controls.VisualElement.Microsoft.Maui.Controls.IPropertyPropagationController.PropagatePropertyChanged(String propertyName)
   at Microsoft.Maui.Controls.Internals.PropertyPropagationExtensions.PropagatePropertyChanged(String propertyName, Element element, IEnumerable children)
   at Microsoft.Maui.Controls.VisualElement.Microsoft.Maui.Controls.IPropertyPropagationController.PropagatePropertyChanged(String propertyName)
   at Microsoft.Maui.Controls.Internals.PropertyPropagationExtensions.PropagatePropertyChanged(String propertyName, Element element, IEnumerable children)
   at Microsoft.Maui.Controls.VisualElement.Microsoft.Maui.Controls.IPropertyPropagationController.PropagatePropertyChanged(String propertyName)
   at Microsoft.Maui.Controls.Internals.PropertyPropagationExtensions.PropagatePropertyChanged(String propertyName, Element element, IEnumerable children)
   at Microsoft.Maui.Controls.VisualElement.Microsoft.Maui.Controls.IPropertyPropagationController.PropagatePropertyChanged(String propertyName)
   at Microsoft.Maui.Controls.Element.OnParentSet()
   at Microsoft.Maui.Controls.NavigableElement.OnParentSet()
   at Microsoft.Maui.Controls.Page.OnParentSet()
   at Microsoft.Maui.Controls.Element.SetParent(Element value)
   at Microsoft.Maui.Controls.Element.OnChildRemoved(Element child, Int32 oldLogicalIndex)
   at Microsoft.Maui.Controls.Element.RemoveLogicalChild(Element element, Int32 index)
   at Microsoft.Maui.Controls.Element.RemoveLogicalChild(Element element)
   at Microsoft.Maui.Controls.Platform.ModalNavigationManager.PopModalAsync(Boolean animated)
   at Microsoft.Maui.Controls.Shell.NavigationImpl.OnPopModal(Boolean animated)
   at Microsoft.Maui.Controls.ShellSection.PopModalStackToPage(Page page, Nullable`1 animated)
   at Microsoft.Maui.Controls.ShellNavigationManager.GoToAsync(ShellNavigationParameters shellNavigationParameters, ShellNavigationRequest navigationRequest)
   at Microsoft.Maui.Controls.Shell.NavigationImpl.OnPopModal(Boolean animated)
   at BindingToInvalidObject.PersonPage.<>c__DisplayClass1_0.<<-ctor>b__0>d.MoveNext() in C:\Temp\ThrowAwayCode\BindingToInvalidObject\BindingToInvalidObject\PersonPage.xaml.cs:line 25
