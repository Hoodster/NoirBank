import React from 'react'
import { useDispatch } from 'react-redux'
import { DEPOSIT_MONEY } from '../../modals/constants'
import { open } from '../../redux/reducers/modal-reducer'
import Button from '../inputs/button/button'
import styles from './quick-view.module.scss'

function BankAccountQuickview(props) {
	const dispatch = useDispatch()


	const openDepositModal = () => {
		dispatch(open({
			type: DEPOSIT_MONEY,
			data: {
				accountNumber: props.accountKey
			}
		}))
	}

	return (
		<div className={styles['nb-account-quickview']}>
			<div className={styles.details}>
				<span className={styles.type}>{props.type}</span>
				<span className={styles.name}>{props.name}</span>
				<div>
					<span className={styles.number}>{props.accountNumber}</span>
					<div style={{ 'marginTop': '18px' }}>
						<span className={styles.amount}>{props.fulls}</span>
						<span className={styles['amount-c']}>{`.${props.cents}`}</span>
						<span className={styles.currency}>  PLN</span>
					</div>
				</div>
			</div>
			<div>
				{
					!props.isLocked ? <Button buttonStyle='accent-inverted' type='general' text='Deposit money' onClick={openDepositModal} /> : <h5>Account has been locked</h5>
				}
			</div>
		</div>
	)
}

export default BankAccountQuickview