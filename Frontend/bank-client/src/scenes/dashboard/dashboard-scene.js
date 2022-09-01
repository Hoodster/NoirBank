import React, { useEffect } from 'react'
import MainBar from '../../components/mainbar/main-bar'
import AccountsScene from './subscenes/accounts/accounts-scene'
import CardsScene from './subscenes/cards/cards-scene'
import OthersScene from './subscenes/others/others-scene'

import './dashboard-scene.scss'
import { userAPI } from '../../helpers/endpoints'
import { useDispatch } from 'react-redux'
import { addProfile } from '../../redux/reducers/user-reducer'
import { get } from '../../helpers/api'
function DashboardScene() {
	const dispatch = useDispatch()

	useEffect(() => {
		get(`${userAPI}/profile`)
			.then((response) => {
				dispatch(addProfile(response.data.data))
			})
	}, [])

	return (<div className='nb-dash'>
		<MainBar />
		<CardsScene />
		<AccountsScene />
		<OthersScene />
	</div>)
}

export default DashboardScene