/** @type {import('tailwindcss').Config} */
module.exports = {
  content: [
    "./src/**/*.{html,ts}"
  ],
  theme: {
    extend: {
      keyframes: {
        shake: {
          '33%': { transform: 'translateX(-2px)'},
          '66%': { transform: 'translateX(4px)'},
        }
      },
      animation: {
        'shake': 'shake 0.5s linear'
      }
    },
  },
  plugins: [],
}

