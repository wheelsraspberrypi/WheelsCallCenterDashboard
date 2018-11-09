using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq.Expressions;

namespace WheelsCallCenterDashboard.ViewModels.Abstract
{
    public interface IBaseViewModel {
    }
    public class BaseViewModel<T> : IBaseViewModel, INotifyPropertyChanged
    {
        [Conditional("DEBUG")]
        [DebuggerStepThrough]
        public void VerifyPropertyName(string propertyName)
        {
            if (TypeDescriptor.GetProperties(this)[propertyName] == null)
            {
                string msg = "Invalid property name: " + propertyName;
                throw new Exception(msg);
            }
        }

        protected void RaisePropertyChanged(Expression<Func<T, object>> action)
        {
            var memberInfo = GetMemberInfo(action);
            VerifyPropertyName(memberInfo.Member.Name);
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(memberInfo.Member.Name));
        }

        private MemberExpression GetMemberInfo(Expression method)
        {
            var lambda = method as LambdaExpression;
            if (lambda == null)
                throw new ArgumentNullException("method");

            MemberExpression memberExpr = null;

            if (lambda.Body.NodeType == ExpressionType.Convert)
            {
                memberExpr =
                    ((UnaryExpression)lambda.Body).Operand as MemberExpression;
            }
            else if (lambda.Body.NodeType == ExpressionType.MemberAccess)
            {
                memberExpr = lambda.Body as MemberExpression;
            }

            if (memberExpr == null)
                throw new ArgumentException("method");

            return memberExpr;
        }


        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion
    }
}
