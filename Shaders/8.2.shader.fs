#version 330 core
out vec4 FragColor;

in vec2 TexCoord;
in vec3 Normal;
in vec3 FragPos;





struct Material
{
	vec3 ambient;
	vec3 diffuse;
	vec3 specular;
	float shininess;
};
struct Light {
    vec3 position;

    vec3 ambient;
    vec3 diffuse;
    vec3 specular;
};

// texture samplers
uniform sampler2D texture1;
uniform sampler2D texture2;
uniform Material material;
uniform Light light;
uniform vec3 viewPos;



void main()
{

	vec4 color =mix(texture(texture1, TexCoord), texture(texture2, TexCoord), 0.4);
	
	//ambient 
  	vec3 ambient = light.ambient * material.ambient;
	
	//diffuse(Half Lambert diffuse)
	vec3 norm = normalize(Normal);

	vec3 LightDir = normalize(light.position - FragPos);
	float diff = max(dot(norm,LightDir),0.0);
	diff = diff*0.5 + 0.5;
	vec3 diffuse = light.diffuse * (diff * material.diffuse);

	//specular
	vec3 viewDir = normalize(viewPos - FragPos);
	vec3 halfDir = normalize(viewDir + LightDir);
	float spec = pow(max(dot(halfDir,norm),0.0),64);
	float specc = spec / 4.0;
	spec +=specc;
	vec3 specular = light.specular*(spec *material.specular);

	vec3 result = ambient+diffuse+specular;
	FragColor = vec4(result,1.0)*color;

}