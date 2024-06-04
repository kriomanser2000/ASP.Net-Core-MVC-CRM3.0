var MMSUtils =
{
    equalizeHeight: function (selector)
    {
        var highest;
        var first = 1;
        selector.each(function ()
        {
            if (first == 1)
            {
                highest = $(this);
                first = 0;
            }
            else
            {
                if (highest.height() < $(this).height())
                {
                    highest = $(this);
                }
            }
        });
        selector.css('height', highest.height());
    }
}