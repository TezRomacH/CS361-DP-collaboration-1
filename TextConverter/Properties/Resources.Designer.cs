﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TextConverter.Properties {
    using System;
    
    
    /// <summary>
    ///   Класс ресурса со строгой типизацией для поиска локализованных строк и т.д.
    /// </summary>
    // Этот класс создан автоматически классом StronglyTypedResourceBuilder
    // с помощью такого средства, как ResGen или Visual Studio.
    // Чтобы добавить или удалить член, измените файл .ResX и снова запустите ResGen
    // с параметром /str или перестройте свой проект VS.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Возвращает кэшированный экземпляр ResourceManager, использованный этим классом.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("TextConverter.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Перезаписывает свойство CurrentUICulture текущего потока для всех
        ///   обращений к ресурсу с помощью этого класса ресурса со строгой типизацией.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на About.
        /// </summary>
        internal static string about {
            get {
                return ResourceManager.GetString("about", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Designed by Roman Tezikov and Tatiana Popova.
        /// </summary>
        internal static string about_message {
            get {
                return ResourceManager.GetString("about_message", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Convert to.
        /// </summary>
        internal static string convert {
            get {
                return ResourceManager.GetString("convert", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Text converter can&apos;t open a file!.
        /// </summary>
        internal static string error_message_cant_open {
            get {
                return ResourceManager.GetString("error_message_cant_open", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Text converter can&apos;t save a file!.
        /// </summary>
        internal static string error_message_cant_save {
            get {
                return ResourceManager.GetString("error_message_cant_save", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Unexpected error!.
        /// </summary>
        internal static string error_title {
            get {
                return ResourceManager.GetString("error_title", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на English.
        /// </summary>
        internal static string lang_eng {
            get {
                return ResourceManager.GetString("lang_eng", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Russian.
        /// </summary>
        internal static string lang_rus {
            get {
                return ResourceManager.GetString("lang_rus", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Languages.
        /// </summary>
        internal static string languages {
            get {
                return ResourceManager.GetString("languages", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Open.
        /// </summary>
        internal static string open {
            get {
                return ResourceManager.GetString("open", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на All files (*.*)|*.*|Text files (*.txt)|*.txt.
        /// </summary>
        internal static string open_file_filter {
            get {
                return ResourceManager.GetString("open_file_filter", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Save.
        /// </summary>
        internal static string save {
            get {
                return ResourceManager.GetString("save", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Save as.
        /// </summary>
        internal static string save_as {
            get {
                return ResourceManager.GetString("save_as", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на HTML files (*.html)|*.html|Text files (*.txt)|*.txt.
        /// </summary>
        internal static string save_file_filter_html {
            get {
                return ResourceManager.GetString("save_file_filter_html", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Markdown files (*.md)|*.md|Text files (*.txt)|*.txt.
        /// </summary>
        internal static string save_file_filter_md {
            get {
                return ResourceManager.GetString("save_file_filter_md", resourceCulture);
            }
        }
    }
}
