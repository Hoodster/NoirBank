import React from 'react'
import { useDispatch } from 'react-redux'
import ModalBase from '../../components/modal/modal-base'
import { close } from '../../redux/reducers/modal-reducer'

function CreateAccountModal() {
	const dispatch = useDispatch()

	const primaryAction = {
		text: 'Create new account',
		action: () => alert('account created'),
		icon: 'wallet'
	}

	const secondaryAction = {
		text: 'Cancel',
		action: () => dispatch(close())
	}

	return (
		<ModalBase title='Create new account' primaryAction={primaryAction} secondaryAction={secondaryAction}>
		</ModalBase>
	)
}

export default CreateAccountModal