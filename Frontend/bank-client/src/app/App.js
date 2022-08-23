/* eslint-disable no-unused-vars */
import React from 'react'
import './App.scss'
import DashboardScene from '../scenes/dashboard/dashboard-scene'
import RegistrationScene from '../scenes/registration/registration-scene'
import { Routes, Route } from 'react-router-dom'
import LoginScene from '../scenes/login/login-scene'
import ModalBase from '../components/modal/modal-base'
import { isModalOpened } from './selectors'
import ActiveModal from '../modals'

function App() {
	return (
		<div className="client-body">
			<Routes>
				<Route path='/' element={<DashboardScene />} />
				<Route path='/registration' element={<RegistrationScene />} />
				<Route path='/login' element={<LoginScene />} />
			</Routes>
			{isModalOpened() ? <ActiveModal /> : null}
		</div>
	)
}

export default App