#version 330 core

out vec4 FragColor;

// in vec2 TexCoords;
in vec3 Position;
in vec3 Normal;

// uniform sampler2D texture1;
uniform vec3 cameraPos;
uniform samplerCube skybox;

void main()
{
    // define Refractive Index
    float ratio = 1.00/1.52;
    //FragColor = texture(texture1,TexCoords);
    vec3 I = normalize(Position-cameraPos);
    vec3 R = refract(I, normalize(Normal),ratio);// reflect!=refract
    FragColor = vec4(texture(skybox,R).rgb,1.0);
}