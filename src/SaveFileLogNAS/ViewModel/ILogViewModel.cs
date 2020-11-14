namespace SaveFileLogNAS.ViewModel
{
    public interface ILogViewModel
    {
        /// <summary>
        /// Log Content Text.
        /// </summary>
        string LogContentText { get; set; }

        /// <summary>
        /// Info Name Text.
        /// </summary>
        string InfoNameText { get; set; }

        /// <summary>
        /// Is Error.
        /// </summary>
        bool IsError { get; set; }
    }
}
