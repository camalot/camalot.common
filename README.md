camalot.common
==============

> Camalot.Common is a collection of classes, extensions and other things that I have written over the years that I used to find myself copying the files 
in to my projects every time I created them. 

## Where do I get it?
### Source
Well, I think you found that one already...
### Binaries
Available on nuget
> PS> Install-Package Camalot.Common

## What does it have?

### Extensions (Camalot.Common.Extensions)
* There are way too many to list here. Go check out the source.

### Serialization (Camalot.Common.Serialization)
* JsonSerializationBuilder : This creates a Newtonsoft.Json Serializer
* XmlSerializationBuilder : This creates an XmlSerializer

## Camalot.Common.Mvc
> There are additional libraries that are specifically built for ASPNET MVC. Support for versions MVC3, MVC4, MVC5. 

## Where do I get it?
### Source
Well, I think you found that one already...
### Binaries
Available on nuget
> PS> Install-Package Camalot.Common.Mvc

> PS> Install-Package Camalot.Common.Mvc4

> PS> Install-Package Camalot.Common.Mvc5

## What does it have?
###Attributes (Camalot.Common.Mvc.Attributes)
* AjaxOnly : The Action is only to be called via ajax.
* NoCache : The Action will not be cached. This is good to use with AjaxOnly.
* Compress : If the browsers supports it, the response will be gzipped or compressed using DEFLATE.
* AjaxValidateAntiForgeryToken : This allows you to post JSON via ajax, and pass an Anti-Forgery Token along in the request headers. 
This can be used if you are posting normally with a Form as well. 

### Results (Camalot.Common.Mvc.Results)
* JsonResult&lt;T&gt; : Like the default JsonResult, except it uses Newtonsoft JSON.NET
* JsonpResult&lt;T&gt; : Support JSONP responses
* XmlResult&lt;T&gt; : Xml Serialization Result
* BsonResult&lt;T&gt; : BSON Serialization Result

### Extensions (Camalot.Common.Mvc.Extensions)
* BundleCollection
 * LoadFromWebConfiguration : This loads Script/Style bundles from the web.config. 
See the &lt;camalot.common/bundles&gt; section in the web.config for samples. In the BundleConfig you can delete it all and just call
this method and be done. 
* Controller 
 * JSON&lt;T&gt;(T data) : A clean serialization of an object to JSON
 * BSON&lt;T&gt;(T data) : A clean serialization of an object to BSON
 * JSONP&lt;T&gt;(T data [, callback]) : Support for JSONP Action Result.
 * XML&lt;T&gt;(T data) : A clean serialization of an object to XML
