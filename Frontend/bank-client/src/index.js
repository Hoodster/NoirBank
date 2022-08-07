import React from 'react'
import ReactDOM from 'react-dom/client'
import './index.scss'
import App from './App'
import { store } from './redux/store'
import { Provider } from 'react-redux'
import { ThemeProvider } from 'next-themes'

const root = ReactDOM.createRoot(document.getElementById('root'))
root.render(
	<React.StrictMode>
		<Provider store={store}>
			<ThemeProvider>
				<App />
			</ThemeProvider>
		</Provider>
	</React.StrictMode>
)

