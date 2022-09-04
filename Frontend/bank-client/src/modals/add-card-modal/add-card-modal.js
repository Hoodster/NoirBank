import React from 'react'
import { useDispatch } from 'react-redux'
import ModalBase from '../../components/modal/modal-base'
import { post } from '../../helpers/api'
import { cardAPI } from '../../helpers/endpoints'
import { close } from '../../redux/reducers/modal-reducer'
import AddCardForm from './add-card-form'
import { getModalData } from './selectors'

function AddCardModal() {
	const dispatch = useDispatch()
	const modalData = getModalData()

	const addCard = () => {
		const requestData = {
			type: modalData.type,
			account: modalData.account,
			cover: modalData.style
		}

		post(`${cardAPI}`, requestData).then(() => dispatch(close()))
	}

	const primaryActionButton = {
		action: () => addCard(),
		text: 'Add new card',
		icon: 'add_card'
	}
	const secondaryActionButton = {
		action: () => dispatch(close()),
		text: 'Cancel'
	}

	return (
		<ModalBase primaryAction={primaryActionButton} secondaryAction={secondaryActionButton} contentPosition='center' title='Add new card'>
			<AddCardForm />
		</ModalBase>
	)
}

export default AddCardModal