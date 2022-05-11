#version 330 core
out vec4 FragColor;

in vec2 TexCoord;
uniform vec3 lightColor;


// texture samplers
uniform sampler2D texture1;
uniform sampler2D texture2;

void main()
{

	FragColor =vec4(lightColor,1.0)*mix(texture(texture1, TexCoord), texture(texture2, TexCoord), 0.4);
}