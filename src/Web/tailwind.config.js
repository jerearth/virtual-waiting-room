/** @type {import('tailwindcss').Config} */
module.exports = {
  content: ["./**/*.{razor,html,cshtml}"],
  theme: {
      screens: {
          xxs: '340px',
          xs: '410px',
          sm: '480px',
          s: '590px',
          md: '720px',
          m: '850px',
          lg: '976px',
          l: '1200px',
          xl: '1440px'
      },
      extend: {
          colors: {
              primary: 'hsl(0, 0%, 13%)',
              secondary: 'hsl(42, 70%, 87%)',
              tertiary: 'hsl(0, 0%, 80%)',
              contrast: 'hsl(21, 100%, 56%)',
              contrastHover: 'hsl(21, 100%, 40%)',
            }
      },
  },
  plugins: [],
};
