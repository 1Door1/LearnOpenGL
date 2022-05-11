#version 330 core
out vec4 FragColor;

in vec2 TexCoord;

in vec3 Normal;
in vec3 FragPos;

uniform vec3 lightColor;
uniform vec3 lightPos;
uniform vec3 viewPos;
vec3 diffuse=vec3(0.5,0.5,0.5);
vec3 specular=vec3(3.0,3.0,3.0);



// texture samplers
uniform sampler2D texture1;
uniform sampler2D texture2;

void main()
{

	vec4 color =mix(texture(texture1, TexCoord), texture(texture2, TexCoord), 0.4);
	//ambient 
	float ambientStrength = 0.2;
	vec3 ambient = ambientStrength*lightColor;
	
	//diffuse(Half Lambert diffuse)
	vec3 norm = normalize(Normal);

	vec3 LightDir = normalize(lightPos - FragPos);//
	float diff = max(dot(norm,LightDir),0.0);
	diff = diff*0.5 + 0.5;
	vec3 diffLight = diffuse * diff * lightColor;

	//specular
	vec3 viewDir = normalize(viewPos - FragPos);//?
	vec3 halfDir = normalize(viewDir + LightDir);
	float spec = pow(max(dot(halfDir,norm),0.0),64);
	float specc = spec / 4.0;
	spec +=specc;
	vec3 specularcolor = spec * specular * lightColor;

	vec4 result = vec4((diffLight+specularcolor),1.0)*color;//check : diffLight+ambient+specularcolor
	FragColor = result;

}