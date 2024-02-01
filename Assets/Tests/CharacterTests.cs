using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

namespace Sample
{
    [TestFixture]
    public sealed class CharacterTests
    {
        private GameObject character;

        [UnityTest]
        public IEnumerator DamageTest()
        {
            //Arange:
            yield return this.Initialize();
            
            var healthComponent = this.character.GetComponent<HealthComponent>();
            healthComponent.Health = 10;
            
            //Act:
            healthComponent.TakeDamage(5);
            
            //Assert:
            Assert.AreEqual(healthComponent.Health, 5);
            
            yield return new WaitForFixedUpdate();
            Assert.IsTrue(this.character.activeSelf);
        }

        [UnityTest]
        public IEnumerator RestoreHealthTest()
        {
            //Arange:
            yield return this.Initialize();
            
            var healthComponent = this.character.GetComponent<HealthComponent>();
            healthComponent.MaxHealth = 10;
            healthComponent.Health = 0;
            this.character.SetActive(false);
            
            //Act:
            healthComponent.RestoreHitPoints(5);
            
            //Assert:
            Assert.AreEqual(healthComponent.Health, 5);
         
            yield return new WaitForSeconds(1);
            Assert.IsTrue(this.character.activeSelf);
            
            //Act:
            healthComponent.RestoreHitPoints(20);

            //Assert:
            Assert.AreEqual(healthComponent.Health, 10);
        }

        [UnityTest]
        public IEnumerator DeathTest()
        {
            //Arange:
            yield return this.Initialize();
            
            var healthComponent = this.character.GetComponent<HealthComponent>();
            healthComponent.Health = 10;
            
            //Act:
            healthComponent.TakeDamage(15);
            
            //Assert:
            Assert.AreEqual(healthComponent.Health, 0);
            
            yield return new WaitForSeconds(1);
            Assert.IsTrue(!this.character.activeSelf);
        }

        [UnityTest]
        public IEnumerator MoveForwardTest()
        {
            //Arange:
            yield return this.Initialize();

            var transform = this.character.transform;
            transform.position = Vector3.zero;
            
            //Act:
            const float moveSpeed = 5;
            const float moveFrames = 100;
            
            var moveComponent = this.character.GetComponent<MoveComponent>();
            moveComponent.MoveSpeed = moveSpeed;
            moveComponent.MoveDirection = Vector3.forward;

            for (int i = 0; i < moveFrames; i++)
            {
                yield return new WaitForFixedUpdate();
            }

            //Assert:
            Vector3 diff = transform.position - new Vector3(0, 0, moveSpeed * moveFrames * Time.fixedDeltaTime);
            Assert.AreEqual(diff.magnitude, 0, 1e-2);
        }
        
        
        [UnityTest]
        public IEnumerator MoveDiagonalTest()
        {
            //Arange:
            yield return this.Initialize();

            var transform = this.character.transform;
            transform.position = Vector3.zero;
            
            //Act:
            const float moveSpeed = 5;
            const float moveFrames = 100;
            
            var moveComponent = this.character.GetComponent<MoveComponent>();
            moveComponent.MoveSpeed = moveSpeed;
            moveComponent.MoveDirection = new Vector3(-1, 0, -1);

            for (int i = 0; i < moveFrames; i++)
            {
                yield return new WaitForFixedUpdate();
            }

            //Assert:
            float end = -moveSpeed * moveFrames * Time.fixedDeltaTime;
            Vector3 diff = transform.position - new Vector3(end, 0, end);
            Assert.AreEqual(diff.magnitude, 0, 1e-2);
        }

        [UnityTest]
        public IEnumerator RotationTest()
        {
            //Arange:
            yield return this.Initialize();
            
            var transform = this.character.transform;
            transform.position = Vector3.zero;

            //Act:
            const float rotationSpeed = 200;
            var rotationComponent = this.character.GetComponent<RotationComponent>();
            rotationComponent.RotationSpeed = rotationSpeed;
            rotationComponent.RotationDirection = Vector3.back;

            yield return new WaitForSeconds(2.0f);

            //Assert:
            Assert.AreEqual(transform.eulerAngles.y, 180, 1e-2);
            
            //Act:
            rotationComponent.RotationDirection = Vector3.forward;
            yield return new WaitForSeconds(2.0f);

            //Assert:
            Assert.AreEqual(transform.eulerAngles.y, 0, 1e-2);
            
            //Act:
            rotationComponent.RotationDirection = new Vector3(-1, 0, -1);
            yield return new WaitForSeconds(2.0f);

            //Assert:
            Assert.AreEqual(transform.eulerAngles.y, 225, 1e-2);
            
            //Act:
            rotationComponent.RotationDirection = new Vector3(1, 0, -1);
            yield return new WaitForSeconds(2.0f);
            
            //Assert:
            Assert.AreEqual(transform.eulerAngles.y, 135, 1e-2);
            
            //Act:
            rotationComponent.RotationDirection = Vector3.zero;
            yield return new WaitForSeconds(1.0f);
            
            //Assert:
            Assert.AreEqual(transform.eulerAngles.y, 135, 1e-2);
        }

        [UnityTest]
        private IEnumerator IntegrationTest()
        {
            //Arange:
            yield return this.Initialize();
            
            var transform = this.character.transform;
            transform.position = Vector3.zero;
            
            var healthComponent = this.character.GetComponent<HealthComponent>();
            healthComponent.MaxHealth = 1;
            healthComponent.Health = 0;

            var moveComponent = this.character.GetComponent<MoveComponent>();
            moveComponent.MoveSpeed = 5;
            moveComponent.MoveDirection = Vector3.forward;
            
            var rotationComponent = this.character.GetComponent<RotationComponent>();
            rotationComponent.RotationSpeed = 5;
            rotationComponent.RotationDirection = Vector3.forward;

            //Act:
            yield return new WaitForSeconds(2.0f);
            
            //Assert:
            Assert.AreEqual(transform.eulerAngles.y, 0.0f, 1e-2);
            Assert.AreEqual(transform.position.x, 0.0f, 1e-2);
            Assert.AreEqual(transform.position.z, 0.0f, 1e-2);
            Assert.IsFalse(this.character.activeSelf);

            //Arange:
            healthComponent.Health = 1;
            
            //Act:
            yield return new WaitForSeconds(2.0f);
            Assert.IsTrue(this.character.activeSelf);
            Assert.AreNotEqual(transform.eulerAngles.y, 0.0f);
            Assert.AreNotEqual(transform.position.x, 0.0f);
            Assert.AreNotEqual(transform.position.z, 0.0f);
        }

        private IEnumerator Initialize()
        {
            AsyncOperation operation = SceneManager.LoadSceneAsync("SampleScene", LoadSceneMode.Single);
            while (!operation.isDone)
            {
                yield return null;
            }
            
            this.character = GameObject.FindGameObjectWithTag("Player");
        }
    }
}