﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Common
{
    public class BaseViewModel<T, TModel> : CoreViewModel where T : IView where TModel : BaseModel, new()
    {
        public T _View;
        public TModel _Model { get; set; } = new TModel();

        public BaseViewModel(T View)
        {
            _View = View;

            CloseViewCommand = new RelayCommand<object>((p) => { return true; }, async (p) =>
            {
                await _View.CloseView();
            });

            LoadViewCommand = new RelayCommand<object>((p) => { return true; }, async (p) =>
            {
                await LoadView();
            });
        }
        public virtual async Task LoadView()
        {
            await Task.CompletedTask;
        }
    }
}