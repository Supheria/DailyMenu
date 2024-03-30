using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyMenu.UI;

public abstract class ResizeableForm : Form
{
    bool _resizing { get; set; } = false;

    public ResizeableForm()
    {
        ResizeBegin += ResizeableForm_ResizeBegin; ; ;
        ResizeEnd += ResizeableForm_ResizeEnd;
        SizeChanged += ResizeableForm_SizeChanged; ;
    }

    private void ResizeableForm_ResizeBegin(object? sender, EventArgs e) => _resizing = true;

    private void ResizeableForm_ResizeEnd(object? sender, EventArgs e)
    {
        _resizing = false;
        DrawClient();
    }

    private void ResizeableForm_SizeChanged(object? sender, EventArgs e)
    {
        if (_resizing is false)
            DrawClient();
    }

    protected abstract void DrawClient();
}
