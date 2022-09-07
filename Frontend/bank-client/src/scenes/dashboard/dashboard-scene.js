import React, { useEffect, useState } from 'react'
import MainBar from '../../components/mainbar/main-bar'

import './dashboard-scene.scss'
import { get } from '../../helpers/api'
import { userAPI } from '../../helpers/endpoints'
import { useDispatch } from 'react-redux'
import { addProfile } from '../../redux/reducers/user-reducer'
import CustomerContainer from './components/customer-container'
import AdminContainer from './components/admin-container'

function DashboardScene() {
	const dispatch = useDispatch()
	const [role, setRole] = useState()

	useEffect(() => {
		get(`${userAPI}/profile`)
			.then((response) => {
				if (response.data.data.login.includes('adm')) {
					localStorage.setItem('r', 'a')
				} else {
					localStorage.setItem('r', 'c')
				}
				dispatch(addProfile(response.data.data))
				const roleInternal = localStorage.getItem('r')
				setRole(roleInternal === 'a' ? 'Admin' : 'Customer')
			})
	}, [])

	return (<div className='nb-dash'>
		<MainBar />
		{role === 'Admin' ? <AdminContainer /> : <CustomerContainer />}
	</div>)
}

export default DashboardScene