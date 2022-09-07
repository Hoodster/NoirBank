import React from 'react'
import { useDispatch } from 'react-redux'
import ModalBase from '../../components/modal/modal-base'
import { post } from '../../helpers/api'
import { cardAPI } from '../../helpers/endpoints'
import { close } from '../../redux/reducers/modal-reducer'
import { addCard } from '../../redux/reducers/user-reducer'
import AddCardForm from './add-card-form'
import { getModalData } from './selectors'

function AddCardModal() {
	const dispatch = useDispatch()
	const modalData = getModalData()

	const addPaymentCard = () => {
		const requestData = {
			type: modalData.cardType,
			account: modalData.account,
			cover: modalData.cardStyle
		}

		post(`${cardAPI}`, requestData).then((response) => {
			dispatch(addCard(response.data.data))
			dispatch(close())
		})
	}

	const primaryActionButton = {
		action: () => addPaymentCard(),
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