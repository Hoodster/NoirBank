/* eslint-disable indent */
import React from 'react'
import ModalBase from '../components/modal/modal-base'
import AddCardModal from './add-card-modal/add-card-modal'
import { ADD_CARD, CREATE_ACCOUNT } from './constants'
import CreateAccountModal from './create-account-modal/create-account-modal'
import { getModalType } from './selectors'

function ActiveModal() {

	const getModal = () => {
		switch (getModalType()) {
			case ADD_CARD:
				return <AddCardModal />
			case CREATE_ACCOUNT:
				return <CreateAccountModal />
			default:
				return <ModalBase title='Kurwa nie działa' />
		}
	}

	return (
		<React.Fragment>
			{getModal()}
		</React.Fragment>
	)
}

export default ActiveModal	