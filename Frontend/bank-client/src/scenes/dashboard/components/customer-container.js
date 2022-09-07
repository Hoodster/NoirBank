import React from 'react'
import AccountsScene from '../subscenes/accounts/accounts-scene'
import CardsScene from '../subscenes/cards/cards-scene'
import OthersScene from '../subscenes/others/others-scene'

function CustomerContainer() {
	return (
		<React.Fragment>
			<CardsScene />
			<AccountsScene />
			<OthersScene />
		</React.Fragment>
	)
}

export default CustomerContainer