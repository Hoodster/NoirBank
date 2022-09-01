/* eslint-disable no-unused-vars */
import React, { useEffect } from 'react'
import './App.scss'
import DashboardScene from '../scenes/dashboard/dashboard-scene'
import RegistrationScene from '../scenes/registration/registration-scene'
import { Routes, Route } from 'react-router-dom'
import LoginScene from '../scenes/login/login-scene'
import { isModalOpened } from './selectors'
import ActiveModal from '../modals'
import axios from 'axios'
import SnackBar from '../components/snack-bar/SnackBar'
import AuthorizedRoute from '../components/authorized-route/authorized-route'

function App() {
	useEffect(() => {
		axios.interceptors.response.use(function (response) {
			return response
		}, function (error) {
			return Promise.reject(error)
		})
	})

	return (
		<div className="client-body">
			<Routes>
				<Route path='/registration' element={<RegistrationScene />} />
				<Route path='/login' element={<LoginScene />} />
				<Route path='/'
					element={
						<AuthorizedRoute>
							<DashboardScene />
						</AuthorizedRoute>
					}
				/>
			</Routes>
			{isModalOpened() ? <ActiveModal /> : null}
			<SnackBar />
		</div>
	)
}

export default App