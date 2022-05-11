#version 330 core
out vec4 FragColor;

in vec3 ourColor;
in vec2 TexCoord;

// texture samplers
uniform sampler2D texture1;
uniform sampler2D texture2;

void main()
{
	// linearly interpolate between both textures (60% 阿米娅, 40% container)
	FragColor = mix(texture(texture1, TexCoord), texture(texture2, TexCoord), 0.4);
}