# Image Shading
A C# library that allows you to write your own fragment shader.
You can then use your shader to edit an image.
<br>
Library is implemented using a software renderer.

## Integration

### Add DLL:
1. Download the **DLL** from _Release_
2. In Visual Studio, click _Project/Add Reference_
3. Locate the **DLL** and add reference to it

### Link Library to Project
1. Add the directory from _/ImageShading_ to your solution
2. In Visual Studio, click _Project/Add Reference_
3. in _/Project_ locate the library
4. Click **Add Reference**

## Usage

### Custom Fragment Shader
Example shader for color inversion:
```csharp
using ImageShading.Core;
using ImageShading.Math;

public class InverShader : Fragment
{
    public override Vec4 SetFragment(Vec2 coordinates)
    {
        Vec4 pixel = SampleScreenBuffer(coordinates);
        return new Vec4(
            1f - pixel.R,
            1f - pixel.G,
            1f - pixel.B,
            pixel.A
        );
    }
}
```

### Shading Image
How to use your custom shader on a image:
```csharp
public static void Main(string[] args)
{
    ImageShading.Core.Painter.ShadeImage(
        "in_image.jpg",
        "out_image.png",
        new InverShader() 
    );
}
```

### Result
Input: <br>
<img src="resources/in_image.png" alt="Input Image" width="200"/>

Output: <br>
<img src="resources/out_image.png" alt="Output Image" width="200"/>

### Opening the Image
After the image is rendered, you can then open the image in
windows default image viewer. There are 2 ways of achieving it:
<br>
<br>
Add **true** at the end
```csharp
ImageShading.Core.Painter.ShadeImage(
    "in_image.jpg",
    "out_image.png",
    new InverShader(),
    true
);
```
or you can open any image
```csharp
ImageShading.Core.Painter.OpenImage("out_image.png");
```
