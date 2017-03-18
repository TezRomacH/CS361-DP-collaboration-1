using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextConverter.ConverterBuilders
{
    public abstract class ConverterBuilder
    {
        protected StringBuilder result;

        /// <summary>
        /// Добавляет обычный текст
        /// </summary>
        public abstract ConverterBuilder AddText(string text);

        /// <summary>
        /// Добаляет заголовок с уровнем level
        /// </summary>
        public abstract ConverterBuilder AddHeader(string header, HeaderLevels level);

        /// <summary>
        /// Добавляет нумерованный список
        /// </summary>
        public abstract ConverterBuilder AddOrderedList(IEnumerable<string> args);

        /// <summary>
        /// Добавляет маркированный список
        /// </summary>
        public abstract ConverterBuilder AddBulletedList(IEnumerable<string> args);

        /// <summary>
        /// Преобразует данные билдера в строку
        /// </summary>
        /// <remarks>Не переопределять в наследниках!</remarks>
        public override string ToString() => result?.ToString() ?? "";

        /// <summary>
        /// Получает расширение файла, связанного с конкретным билдером.
        /// </summary>
        public virtual string GetExtension() => ".txt";

        /// <summary>
        /// Удаляет все символы из текущего экземпляра ConverterBuilder
        /// </summary>
        public ConverterBuilder Clear()
        {
            result?.Clear();

            return this;
        }
    }
}
