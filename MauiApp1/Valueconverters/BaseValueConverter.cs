using System.Globalization;

namespace MauiApp1
{
    /// <summary>
    /// A base value converter that allows direct XAML usage(직접 XAML 사용을 허용하는 기본 값 변환기)
    /// </summary>
    /// <typeparam name="T">The type of this value converter</typeparam>
    public abstract class BaseValueConverter<T> : IValueConverter 
        where T : class , new() {
        #region Private Members
		/// <summary>
        /// A single static instance of this value converter(이 값 변환기의 단일 정적 인스턴스)
        /// </summary>
        private static T _converter = null;
        #endregion

        #region Markup Extension Methods(마크업 확장 방법)
        /// <summary>
        /// Provides a static instance of the value converter(값 변환기의 정적 인스턴스를 제공합니다.)
        /// </summary>
        /// <param name="serviceProvider">The service provider</param>
        /// <returns></returns>
        public object ProvideValue(IServiceProvider serviceProvider) {
            return _converter ?? ( _converter = new T() );
        } 
        #endregion

        #region Value Converter Methods
        /// <summary>
        /// The method to convert one type to another(하나의 유형을 다른 유형으로 변환하는 방법)
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public abstract object Convert(object value, Type targetType, object parameter, CultureInfo culture);

        /// <summary>
        /// The method to convert a value back to it's source type(값을 소스 유형으로 다시 변환하는 방법)
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public abstract object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture);
        #endregion
    }
}
