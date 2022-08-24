/* eslint-disable indent */
import React from 'react'
import AddCardModal from './add-card-modal/add-card-modal'
import { ADD_CARD, CREATE_ACCOUNT, MAKE_TRANSFER } from './constants'
import CreateAccountModal from './create-account-modal/create-account-modal'
import DefaultModal from './default-modal/default-modal'
import MakeTransferModal from './make-transfer-modal/make-transfer-modal'
import { getModalType } from './selectors'

function ActiveModal() {

	const getModal = () => {
		switch (getModalType()) {
			case ADD_CARD:
				return <AddCardModal />
			case CREATE_ACCOUNT:
				return <CreateAccountModal />
			case MAKE_TRANSFER:
				return <MakeTransferModal />
			default:
				return <DefaultModal />
		}
	}

	return (
		<React.Fragment>
			{getModal()}
		</React.Fragment>
	)
}

export default ActiveModal	