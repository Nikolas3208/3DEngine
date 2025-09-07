using _3DEngine.Core.Mathematics;
using OpenTK.Graphics.OpenGL4;

namespace _3DEngine.Renderer
{
    /// <summary>
    /// Класс для работы с шейдерами в OpenGL.
    /// Позволяет загружать, компилировать и использовать шейдеры, а также управлять их униформами.
    /// </summary>
    public class Shader
    {
        /// <summary>
        /// Идентификатор программы шейдера в OpenGL.
        /// </summary>
        public int Handle { get; }

        /// <summary>
        /// Словарь для хранения локаций униформов по их именам.
        /// </summary>
        private Dictionary<string, int> uniformLocations;

        /// <summary>
        /// Конструктор класса Shader. Загружает и компилирует шейдеры, а затем связывает их в программу.
        /// </summary>
        /// <param name="vertPath">Путь к файлу вершинного шейдера.</param>
        /// <param name="fragPath">Путь к файлу фрагментного шейдера.</param>
        /// <param name="geomPath">Путь к файлу геометрического шейдера (опционально).</param>
        public Shader(string vertPath, string fragPath, string geomPath = "")
        {
            int Handle = GL.CreateProgram();

            // Загрузка и компиляция вершинного шейдера
            string shaderSource = File.ReadAllText(vertPath);
            int shaderVert = CreateShader(ShaderType.VertexShader, shaderSource);

            // Загрузка и компиляция фрагментного шейдера
            shaderSource = File.ReadAllText(fragPath);
            int shaderFrag = CreateShader(ShaderType.FragmentShader, shaderSource);

            // Загрузка и компиляция геометрического шейдера (если указан)
            int shaderGeom = -1;
            if (geomPath != "")
            {
                shaderSource = File.ReadAllText(geomPath);
                shaderGeom = CreateShader(ShaderType.GeometryShader, shaderSource);
            }

            // Присоединение шейдеров к программе
            GL.AttachShader(Handle, shaderVert);
            if (shaderGeom != -1)
                GL.AttachShader(Handle, shaderGeom);
            GL.AttachShader(Handle, shaderFrag);

            // Линковка программы
            LinkProgram(Handle);

            // Отсоединение и удаление шейдеров после линковки
            GL.DetachShader(Handle, shaderFrag);
            GL.DetachShader(Handle, shaderVert);
            GL.DetachShader(Handle, shaderGeom);

            GL.DeleteShader(shaderFrag);
            GL.DeleteShader(shaderVert);
            GL.DeleteShader(shaderGeom);

            // Получение локаций униформов
            GetUniformsLocation(Handle);

            this.Handle = Handle;
        }

        /// <summary>
        /// Получает локации всех униформов в шейдерной программе.
        /// </summary>
        /// <param name="handle">Идентификатор программы шейдера.</param>
        private void GetUniformsLocation(int handle)
        {
            GL.GetProgram(handle, GetProgramParameterName.ActiveUniforms, out int uniformsCount);

            uniformLocations = new Dictionary<string, int>();

            for (int i = 0; i < uniformsCount; i++)
            {
                string key = GL.GetActiveUniform(handle, i, out _, out _);

                int location = GL.GetUniformLocation(handle, key);

                uniformLocations.Add(key, location);
            }
        }

        /// <summary>
        /// Линкует шейдерную программу и проверяет на ошибки.
        /// </summary>
        /// <param name="handle">Идентификатор программы шейдера.</param>
        private void LinkProgram(int handle)
        {
            GL.LinkProgram(handle);

            GL.GetProgram(handle, GetProgramParameterName.LinkStatus, out var status);
            if (status != (int)All.True)
            {
                var log = GL.GetProgramInfoLog(handle);
                throw new Exception($"Ошибка при линковке программы ({handle}).\n\n{log}");
            }
        }

        /// <summary>
        /// Создает и компилирует шейдер указанного типа.
        /// </summary>
        /// <param name="shaderType">Тип шейдера (вершинный, фрагментный и т.д.).</param>
        /// <param name="source">Исходный код шейдера.</param>
        /// <returns>Идентификатор созданного шейдера.</returns>
        private int CreateShader(ShaderType shaderType, string source)
        {
            int shader = GL.CreateShader(shaderType);

            GL.ShaderSource(shader, source);

            CompileShader(shader);

            return shader;
        }

        /// <summary>
        /// Компилирует шейдер и проверяет на ошибки.
        /// </summary>
        /// <param name="shader">Идентификатор шейдера.</param>
        private void CompileShader(int shader)
        {
            GL.CompileShader(shader);

            GL.GetShader(shader, ShaderParameter.CompileStatus, out var status);
            if (status != (int)All.True)
            {
                var log = GL.GetShaderInfoLog(shader);
                throw new Exception($"Ошибка при компиляции шейдера ({shader}).\n\n{log}");
            }
        }

        /// <summary>
        /// Активирует шейдерную программу для использования.
        /// </summary>
        public void Use()
        {
            GL.UseProgram(Handle);
        }

        /// <summary>
        /// Получает локацию атрибута по имени.
        /// </summary>
        /// <param name="name">Имя атрибута.</param>
        /// <returns>Локация атрибута.</returns>
        public int GetAttribLocation(string name)
        {
            return GL.GetAttribLocation(Handle, name);
        }

        /// <summary>
        /// Получает локацию униформа по имени.
        /// </summary>
        /// <param name="name">Имя униформа.</param>
        /// <returns>Локация униформа.</returns>
        public int GetUniformLocation(string name)
        {
            return uniformLocations[name];
        }

        /// <summary>
        /// Проверяет, существует ли униформ с указанным именем.
        /// </summary>
        /// <param name="name">Имя униформа.</param>
        /// <returns>True, если униформ существует, иначе False.</returns>
        public bool ContainsKey(string name)
        {
            return uniformLocations.ContainsKey(name);
        }

        /// <summary>
        /// Получает индекс блока униформов по имени.
        /// </summary>
        /// <param name="name">Имя блока униформов.</param>
        /// <returns>Индекс блока униформов.</returns>
        public int GetUniformBlockIndex(string name)
        {
            return GL.GetUniformBlockIndex(Handle, name);
        }

        /// <summary>
        /// Активирует блок униформов с заданным биндингом.
        /// </summary>
        /// <param name="name">Имя блока униформов.</param>
        /// <param name="binding">Биндинг для блока униформов.</param>
        public void ActiveUniformBlock(string name, int binding)
        {
            int blockIndex = GetUniformBlockIndex(name);
            if (blockIndex == -1)
                throw new Exception($"Блок униформов '{name}' не найден в шейдере.");

            GL.UniformBlockBinding(Handle, blockIndex, binding);
        }

        /// <summary>
        /// Устанавливает значение типа bool для униформа.
        /// </summary>
        public void SetBool(string name, bool value)
        {
            if (ContainsKey(name))
            {
                Use();
                GL.Uniform1(GetUniformLocation(name), value ? 1 : 0);
            }
        }

        /// <summary>
        /// Устанавливает значение типа int для униформа.
        /// </summary>
        public void SetInt(string name, int value)
        {
            if (ContainsKey(name))
            {
                Use();
                GL.Uniform1(GetUniformLocation(name), value);
            }
        }

        /// <summary>
        /// Устанавливает значение типа float для униформа.
        /// </summary>
        public void SetFloat(string name, float value)
        {
            if (ContainsKey(name))
            {
                Use();
                GL.Uniform1(GetUniformLocation(name), value);
            }
        }

        /// <summary>
        /// Устанавливает значение типа Vector3 для униформа.
        /// </summary>
        public void SetVector3(string name, Vector3 value)
        {
            if (ContainsKey(name))
            {
                Use();
                GL.Uniform3(GetUniformLocation(name), value.X, value.Y, value.Z);
            }
        }

        /// <summary>
        /// Устанавливает значение типа Vector4 для униформа.
        /// </summary>
        public void SetVector4(string name, Vector4 value)
        {
            if (ContainsKey(name))
            {
                Use();
                GL.Uniform4(GetUniformLocation(name), value.X, value.Y, value.Z, value.W);
            }
        }

        /// <summary>
        /// Устанавливает значение типа Matrix4 для униформа.
        /// </summary>
        public void SetMatrix4(string name, Matrix4 value)
        {
            if (ContainsKey(name))
            {
                Use();
                GL.UniformMatrix4(GetUniformLocation(name), 16, true, value.GetValues());
            }
        }

        /// <summary>
        /// Деструктор. Удаляет программу шейдера из OpenGL.
        /// </summary>
        ~Shader()
        {
            GL.DeleteProgram(Handle);
        }
    }
}
