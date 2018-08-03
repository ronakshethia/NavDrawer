using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.Content;
using Android.Views;
using Android.Widget;

namespace NavDrawer.Customs
{
   public class CountDrawable : Drawable
    {
        private float mTextSize;
        private Paint mBadgePaint;
        private Paint mTextPaint;
        private Rect mTxtRect = new Rect();

        private String mCount = "";
        private bool mWillDraw = false;


        public CountDrawable(Context context)
        {
            float mTextSize = context.Resources.GetDimension(Resource.Dimension.badge_count_textsize);
            mBadgePaint = new Paint();
            // mBadgePaint.SetCol(ContextCompat.GetColor(context.ApplicationContext, Resource.Color.background_color));
            mBadgePaint.Color = new Color(Color.Red);
            mBadgePaint.AntiAlias = true;
            mBadgePaint.SetStyle(Paint.Style.Fill);

            mTextPaint = new Paint();
            mTextPaint.Color = new Color(Color.White);
            mTextPaint.SetTypeface(Typeface.DefaultBold);
            mTextPaint.TextSize = mTextSize;
            mTextPaint.AntiAlias = true;
            mTextPaint.TextAlign = Paint.Align.Center;
        }


        public override void Draw(Canvas canvas)
        {
            if(!mWillDraw)
            {
                return;
            }



            Rect bounds = GetBounds;
            float width = bounds.Right - bounds.Left;
            float height = bounds.Bottom - bounds.Top;

            float radius = ((Math.Max(width, height) / 2)) / 2;
            float centerX = (width - radius - 1) + 5;
            float centerY = radius - 5;
            if (mCount.Length <= 2)
            {
                // Draw badge circle.
                canvas.DrawCircle(centerX, centerY, (int)(radius + 5.5), mBadgePaint);
            }
            else
            {
                canvas.DrawCircle(centerX, centerY, (int)(radius + 6.5), mBadgePaint);
            }

            mTextPaint.GetTextBounds(mCount, 0, mCount.Length, mTxtRect);
            float textHeight = mTxtRect.Bottom - mTxtRect.Top;
            float textY = centerY + (textHeight / 2f);
            if (mCount.Length > 2)
                canvas.DrawText("99+", centerX, textY, mTextPaint);
            else
                canvas.DrawText(mCount, centerX, textY, mTextPaint);
        }

        public Rect GetBounds { get; set; }
        

        public void setCount(String count)
        {
            mCount = count;

            // Only draw a badge if there are notifications.
           // mWillDraw = !count.equalsIgnoreCase("0");
            mWillDraw = !string.Equals(count, "0", StringComparison.OrdinalIgnoreCase);
           // invalidateSelf();
        }

        public override void SetAlpha(int alpha)
        {
           
        }

        public override void SetColorFilter(ColorFilter colorFilter)
        {
           
        }

        public override int Opacity
        {
            get;
        }

    }



    }