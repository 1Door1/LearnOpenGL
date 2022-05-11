#include<glad/glad.h>
#include<GLFW/glfw3.h>

#include<iostream>

#include "imgui/imgui.h"
#include "imgui/imgui_impl_glfw.h"
#include "imgui/imgui_impl_opengl3.h"

using namespace std;

void framebuffer_size_callback(GLFWwindow* window,int width,int height);
int main()
{
    glfwInit();


    glfwWindowHint(GLFW_CONTEXT_VERSION_MAJOR,3);
    glfwWindowHint(GLFW_CONTEXT_VERSION_MINOR,3);
    glfwWindowHint(GLFW_OPENGL_PROFILE,GLFW_OPENGL_CORE_PROFILE);

    GLFWwindow* window = glfwCreateWindow(800,600,"HelloImgui",NULL,NULL);
    if(window == NULL)
    {
        std::cout <<"Failed to create glfw window"<<std::endl;
        glfwTerminate();
        return -1;
        
    } 
    glfwMakeContextCurrent(window);
    glfwSetFramebufferSizeCallback(window,framebuffer_size_callback);
    
    if(!gladLoadGLLoader((GLADloadproc)glfwGetProcAddress))
    {
        std::cout<< "Failed to initialize GLAD"<< std::endl;
        return -1;
    } 
    const char* glsl_version = "#version 330 core";

    IMGUI_CHECKVERSION();
    ImGui::CreateContext();
    ImGuiIO &io = ImGui::GetIO();
    (void)io;

    ImGui::StyleColorsLight();

    ImGui_ImplGlfw_InitForOpenGL(window,true);
    ImGui_ImplOpenGL3_Init(glsl_version);

    bool deemo_window = true;
    bool another_window = false;

    glViewport(0,0,800,600);

   

    while(!glfwWindowShouldClose(window))
    {
        glfwSwapBuffers(window);
        glfwPollEvents();

        ImGui_ImplOpenGL3_NewFrame();
        ImGui_ImplGlfw_NewFrame();
        ImGui::NewFrame();
        if(deemo_window)
        {

            ImGui::Begin("Debug Page");
            ImGui::Text("Page Selectior");
            ImGui::Checkbox("Main Page",&deemo_window);
            ImGui::Checkbox("Another Page",&another_window);

            ImGui::Text("Keep Pressing LEFT_CTRL to swich Cursor capture mode.");

            ImGui::Text("FPS:%.1f",ImGui::GetIO().Framerate);

            ImGui::End();
        }

        if(another_window)
        {
            ImGui::Begin("Another window",&another_window);

            ImGui::Text("I haven't descide what to put on yet.");

            if(ImGui::Button("Close"))
            another_window = false;

            ImGui::End();
        }
        ImGui::Render();

        ImGui_ImplOpenGL3_RenderDrawData(ImGui::GetDrawData());
    }
    ImGui_ImplOpenGL3_Shutdown();
    ImGui_ImplGlfw_Shutdown();
    ImGui::DestroyContext();

    glfwTerminate();
    return 0;

}


void framebuffer_size_callback(GLFWwindow* window, int width, int height)
{
	glViewport(0, 0, width, height);
}
