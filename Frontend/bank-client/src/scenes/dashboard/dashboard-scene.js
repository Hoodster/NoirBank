import React from 'react'
import MainBar from '../../components/mainbar/mainbar'
import AccountsScene from './subscenes/accounts/accounts-scene'
import CardsScene from './subscenes/cards/cards-scene'
import OthersScene from './subscenes/others/others-scene'

import './dashboard-scene.scss'
function DashboardScene() {
	return (<div className='nb-dash'>
		<MainBar />
		<CardsScene/>
		<AccountsScene/>
		<OthersScene/>
	</div>)
}

export default DashboardScene