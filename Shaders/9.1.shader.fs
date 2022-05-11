#version 330 core
out vec4 FragColor;

in vec2 TexCoords;

uniform sampler2D texture_diffuse1;


void main()
{    
    FragColor = texture(texture_diffuse1, TexCoords);
    //FragColor += texture(texture_diffuse2, TexCoords);

    // FragColor.a = FragColor.a > 1.0 ? 1.0 : FragColor.a;

    // if (FragColor.a < 0.05)
    //     discard;
}