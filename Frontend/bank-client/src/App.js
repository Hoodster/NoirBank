/* eslint-disable no-unused-vars */
import React from 'react'
import './App.scss'
import DashboardScene from './scenes/dashboard/dashboard-scene'
import RegistrationScene from './scenes/registration/registration-scene'
import { Routes, Route } from 'react-router-dom'

function App() {
	return (
		<div className="client-body">
			<Routes>
				<Route path='/' element={<DashboardScene/>}/>
				<Route path='/registration' element={<RegistrationScene/>}/>
			</Routes>
		</div>
	)
}

export default App