import React from 'react'
import './quick-view.scss'

function BankAccountQuickview() {
	return(
		<div className='nb-account-quickview'>
			<div className='details'>
				<span className='type'>Business</span>
				<span className='name'>Sample account name</span>
				<div>
					<span className='number'>1090 1014 0000 0712 1981 2874</span>
					<div>
						<span className='amount'>4600</span>
						<span className='amount-c'>.87</span>
						<span className='currency'>  PLN</span>
					</div>
				</div>
			</div>
		</div>
	)
}

export default BankAccountQuickview