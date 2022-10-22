import React from 'react'
import ReactDOM from 'react-dom/client'
import './index.scss'
import App from './app/App'
import { store } from './redux/store'
import { Provider, useSelector } from 'react-redux'
import { ThemeProvider } from 'next-themes'
import { BrowserRouter } from 'react-router-dom'

const root = ReactDOM.createRoot(document.getElementById('root'))
root.render(
	<React.StrictMode>
		<Provider store={store}>
			<ThemedIndex/>
		</Provider>
	</React.StrictMode>
)

function ThemedIndex() {
	const theme = useSelector(state => state.settings.theme)

	const themeProviderProps = theme !== 'system' ? {
		forcedTheme: theme
	} : {}

	return(
		<ThemeProvider {...themeProviderProps}>
			<BrowserRouter>
				<App />
			</BrowserRouter>
		</ThemeProvider>
	)
}

