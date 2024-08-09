<template>
	<section class="container">
		<hgroup>
			<h1 class="text-center">Post</h1>
		</hgroup>
		<br />
		<div class="row">
			<div class="col">
				<div class="form-group">
					<div class="form-check">
						<label class="form-check-label">
							<input
								v-model="postType"
								type="radio"
								class="form-check-input"
								name="postType"
								id="typeMarketplaces"
								:value="0"
							/>
							Marketplaces
						</label>
					</div>
					<div class="form-check">
						<label class="form-check-label">
							<input
								v-model="postType"
								type="radio"
								class="form-check-input"
								name="postType"
								id="typeSocial"
								:value="1"
							/>
							Social
						</label>
					</div>
					<div class="form-check">
						<label class="form-check-label">
							<input
								v-model="postType"
								type="radio"
								class="form-check-input"
								name="postType"
								id="typeBlogging"
								:value="2"
							/>
							Blogging
						</label>
					</div>
				</div>
			</div>
			<div class="col">
				<div class="form-group" v-if="postType == 0">
					<div class="form-check form-check-inline">
						<label class="form-check-label">
							<input
								class="form-check-input"
								type="checkbox"
								name="cbxAlobg"
								id="cbxAlobg"
								:value="0"
								v-model="postPlatforms"
							/>
							Alo.bg
						</label>
					</div>
					<br />
					<div class="form-check form-check-inline">
						<label class="form-check-label">
							<input
								class="form-check-input"
								type="checkbox"
								name="cbxAmazon"
								id="cbxAmazon"
								:value="1"
								v-model="postPlatforms"
							/>
							Amazon
						</label>
					</div>
					<br />
					<div class="form-check form-check-inline">
						<label class="form-check-label">
							<input
								class="form-check-input"
								type="checkbox"
								name="cbxOlx"
								id="cbxOlx"
								:value="2"
								v-model="postPlatforms"
							/>
							OLX
						</label>
					</div>
					<br />
					<div class="form-check form-check-inline">
						<label class="form-check-label">
							<input
								class="form-check-input"
								type="checkbox"
								name="cbxBazar"
								id="cbxBazar"
								:value="3"
								v-model="postPlatforms"
							/>
							Bazar
						</label>
					</div>
					<br />
					<div class="form-check form-check-inline">
						<label class="form-check-label">
							<input
								class="form-check-input"
								type="checkbox"
								name="cbxEbay"
								id="cbxEbay"
								:value="4"
								v-model="postPlatforms"
							/>
							Ebay
						</label>
					</div>
					<br />
					<div class="form-check form-check-inline">
						<label class="form-check-label">
							<input
								class="form-check-input"
								type="checkbox"
								name="cbxEtsy"
								id="cbxEtsy"
								:value="5"
								v-model="postPlatforms"
							/>
							Etsy
						</label>
					</div>
				</div>
				<div class="form-group" v-if="postType == 1">
					<div class="form-check">
						<label class="form-check-label">
							<input
								type="checkbox"
								class="form-check-input"
								name="cbxFacebook"
								id="cbxFacebook"
								:value="6"
								v-model="postPlatforms"
							/>
							Facebook
						</label>
					</div>
					<div class="form-check">
						<label class="form-check-label">
							<input
								type="checkbox"
								class="form-check-input"
								name="cbxInstagram"
								id="cbxInstagram"
								:value="7"
								v-model="postPlatforms"
							/>
							Instagram
						</label>
					</div>
					<div class="form-check">
						<label class="form-check-label">
							<input
								type="checkbox"
								class="form-check-input"
								name="cbxLinkedIn"
								id="cbxLinkedIn"
								:value="8"
								v-model="postPlatforms"
							/>
							LinkedIn
						</label>
					</div>
					<div class="form-check">
						<label class="form-check-label">
							<input
								type="checkbox"
								class="form-check-input"
								name="cbxTikTok"
								id="cbxTikTok"
								:value="9"
								v-model="postPlatforms"
							/>
							TikTok
						</label>
					</div>
				</div>
				<div class="form-group" v-if="postType == 2">
					<div class="form-check">
						<label class="form-check-label">
							<input
								type="checkbox"
								class="form-check-input"
								name="cbxMedium"
								id="cbxMedium"
								:value="10"
								v-model="postPlatforms"
							/>
							Medium
						</label>
					</div>
					<div class="form-check">
						<label class="form-check-label">
							<input
								type="checkbox"
								class="form-check-input"
								name="cbxBlogger"
								id="cbxBlogger"
								:value="11"
								v-model="postPlatforms"
							/>
							Blogger
						</label>
					</div>
				</div>
			</div>
		</div>
		<br />
		<div class="form-group">
			<label for="postName">Name</label>
			<input
				type="text"
				name="postName"
				id="postName"
				class="form-control"
				placeholder="Name"
				aria-describedby="postName"
				v-model="postName"
			/>
			<small id="postName" class="text-muted">Put the item name here</small>
		</div>
		<br />
		<div class="form-group">
			<label for="postDescription">Description</label>
			<textarea
				name="postDescription"
				id="postDescription"
				class="form-control"
				placeholder="Description"
				aria-describedby="postDescription"
				v-model="postDescription"
			></textarea>
			<small id="postDescription" class="text-muted">Put the description here</small>
		</div>
		<br />
		<div class="custom-file mt-3 mb-3">
			<input
				type="file"
				class="custom-file-input"
				id="pictures"
				style="border: 1px solid black"
			/>
			<br />
			<label class="custom-file-label" for="pictures">Upload pictures</label>
		</div>
		<button @click="publish" class="btn btn-primary text-center">Publish</button>
	</section>
</template>

<script lang="js">
export default {
	data() {
		return {
			postType: 0,
			postPlatforms: [],
			postName: '',
			postDescription: '',
			postPictures: []
		}
	},
	methods: {
		async publish() {
			const data = JSON.stringify({
				Type: this.postType,
				Platforms: this.postPlatforms,
				Name: this.postName,
				Description: this.postDescription,
				Pictures: this.postPictures
			});
			const requestOptions = {
				method: "POST",
				headers: { "Content-Type": "application/json" },
				body: data
			};
			const result = await fetch('Publish/PublishPost', requestOptions);
		}
	}
}
</script>

<style scoped></style>
